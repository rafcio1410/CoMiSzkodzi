using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CoMiSzkodzi.Helpers;
using FreshMvvm;
using Xamarin.Forms;
using CoMiSzkodzi.Databases;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoMiSzkodzi.PageModels
{
    public class AddNewFoodPageModel : FreshBasePageModel
    {
        public AddNewFoodPageModel()
        {
            Title = "Dodaj Nowe Jedzenie";
            CategoriesForPicker = new List<PickerCategories>();
            PopulateCategories();
            CanExecuteAddButton = true;
            NavBarBackgroundColor = Color.Goldenrod;
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
        private string _newFoodEntryText;
        public string NewFoodEntryText
        {
            get
            {
                return _newFoodEntryText;
            }
            set
            {
                _newFoodEntryText = value;
                RaisePropertyChanged("NewFoodEntryText");
            }
        }
        private PickerCategories _selectedItem;
        public PickerCategories SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }
        private List<PickerCategories> _categoriesForPicker;
        public List<PickerCategories> CategoriesForPicker
        {
            get
            {
                return _categoriesForPicker;
            }
            set
            {
                _categoriesForPicker = value;
                RaisePropertyChanged("CategoriesForPicker");
            }
        }

        private void PopulateCategories()
        {
            List<PickerCategories> categories = new List<PickerCategories>();
            categories.Add(new PickerCategories { Name = "Nabial", Categories = Enums.Categories.Diary });
            categories.Add(new PickerCategories { Name = "Napoje", Categories = Enums.Categories.Drinks });
            categories.Add(new PickerCategories { Name = "Owoce", Categories = Enums.Categories.Fruits });
            categories.Add(new PickerCategories { Name = "Gotowe Dania", Categories = Enums.Categories.Meals });
            categories.Add(new PickerCategories { Name = "Miesa", Categories = Enums.Categories.Meats });
            categories.Add(new PickerCategories { Name = "Inne", Categories = Enums.Categories.Others });
            categories.Add(new PickerCategories { Name = "Przekaski", Categories = Enums.Categories.Snacks });
            categories.Add(new PickerCategories { Name = "Przyprawy", Categories = Enums.Categories.Spices });
            categories.Add(new PickerCategories { Name = "Uzytkownika", Categories = Enums.Categories.User });
            categories.Add(new PickerCategories { Name = "Warzywa", Categories = Enums.Categories.Vegetables });
            CategoriesForPicker = categories;

        }
        public List<Food> GetListOfAllProducts()
        {
            var result = DatabaseConnection.Connection.QueryAsync<Food>("Select * FROM FOOD");
            return result.Result;
        }
        public Task<bool> MakeDataBaseCallToAddItemToDatabase()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Food food = new Food();
            food.name = NewFoodEntryText;
            if (SelectedItem != null)
            {
                food.categories = SelectedItem.Categories;
                food.blacklisted = Enums.BlackListed.ToCheck;
                var result = DatabaseConnection.Connection.InsertAsync(food);
                result.Wait();
                if (result.IsCompleted)
                {
                    tcs.SetResult(true);
                    return tcs.Task;
                }
                tcs.SetResult(false);
                return tcs.Task;
            }
            else
            {
                CoreMethods.DisplayAlert("Uwaga", "Nie wybrales kategorii, sprobuj ponownie", "OK");
                tcs.SetResult(false);
                return tcs.Task;
            }
        }
        public Command AddNewFoodCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isAddingProductllowed = await VerifyIfProductExistAndNoSpecialSigns();
                    if(isAddingProductllowed)
                    {
                        var result = await MakeDataBaseCallToAddItemToDatabase();
                        if (result)
                        {
                            await CoreMethods.PopPageModel();
                        }
                    }
                });
            }
        }
        private async Task<bool> VerifyIfProductExistAndNoSpecialSigns()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            var listOfAllProdcuts = GetListOfAllProducts();
            var doesProductExist = listOfAllProdcuts.Where(c => c.name.ToLower() == NewFoodEntryText.ToLower());
            if (String.IsNullOrEmpty(NewFoodEntryText))
            {
                await CoreMethods.DisplayAlert("Uwaga", "Nie wpisales nazwy produktu, sprobuj ponowownie", "OK");
                CanExecuteAddButton = true;
                return false;
            }
            var isSpecialCharacter = CheckForSpecialCharacters();
            if(isSpecialCharacter)
            {
                await CoreMethods.DisplayAlert("Uwaga", "W nazwie sa specjalne znaki, prosze o usuniecie i sprobowanie ponownie", "OK");
                return false;
            }
            if (doesProductExist.Count() > 0)
            {
                var alertResult = await CoreMethods.DisplayAlert("Uwaga", String.Format("Produkt o nazwie {0}, juz istnieje. Czy chcesz dodac mimo wszystko?", NewFoodEntryText), "OK", "Wroc");
                if(alertResult)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool _canExecuteAddButton;
        public bool CanExecuteAddButton
        {
            get
            {
                return _canExecuteAddButton;
            }
            set
            {
                if(value != _canExecuteAddButton)
                {
                    _canExecuteAddButton = value;
                    AddNewFoodCommand.ChangeCanExecute();
                    RaisePropertyChanged("CanExecuteAddButton");
                }

            }
        }
        private bool CheckForSpecialCharacters()
        {
            var removedWhiteSpace = NewFoodEntryText.Replace(" ", "");
            return removedWhiteSpace.Any(c => !Char.IsLetterOrDigit(c));
        }

        public ICommand NavigateHomeCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    var result = await CoreMethods.DisplayAlert("Uwaga", "Czy zapisac zmiany?", "Tak", "Nie");
                    if (result)
                    {
                        await CoreMethods.PopToRoot(false);
                        tcs.SetResult(true);
                    }
                    else
                    {
                        tcs.SetResult(false);
                    }

                });
            }
        }

        public ICommand NavigateBackCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {

                    await CoreMethods.PopPageModel(false);
                });
            }
        }
        private Color _navBarBackgroundColor;
        public Color NavBarBackgroundColor
        {
            get
            {
                return _navBarBackgroundColor;
            }
            set
            {
                _navBarBackgroundColor = value;
                RaisePropertyChanged("NavBarBackgroundColor");
            }
        }
    }
}

