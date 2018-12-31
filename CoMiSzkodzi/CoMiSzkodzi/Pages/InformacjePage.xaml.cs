using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoMiSzkodzi
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformacjePage : ContentPage
	{
		public InformacjePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            InformationsL1.Text =
                                "Aplikacja CoMiSzkodzi została stworzona głównie dla ludzi chorujących na nieswoiste zapelenia jelit oraz dla osób zmagających się z innymi problemami układu pokarmowego. "+
                                "Aplikacja pozwala w prosty i czytelny sposób ustalić jakie spożyte produkty źle działają na nasz organizm. Poniżej znajduję się krótka instrukcja obsługi.";
            InformationsL2.Text = "Instrukcja w punktach: ( Przewiń w dół )";
            InformationsL3.Text = " •  Codziennie prowadź zapis tego co zjadłeś.W tym celu przejdź na stronę 'DZISIEJSZE POSIŁKI' i wybierz z gotowej  bazy produkty jakie dziś spożyłeś." +
                                  "Jeżeli w bazie nie ma danego produktu to masz możliwość dodania go do bazy klikając na plusik  '+'. Po dodaniu wszystkich posiłków kliknij zapisz." +
                                  "W tym momencie spożyte przez Ciebie pokarmy zapiszą się na stronie odpowiadającej danemu dniowi. Czyli jeżeli dzisiaj jest poniedziałek to Twoje posiłki zapiszą się na stronie PODSUMUJ POSIŁKI -> PONIEDZIAŁEK itd.";
            InformationsL4.Text = " •  Po odpowiednim dla Ciebie czasie, czyli czasie po którym możesz stwierdzić czy dany posiłek Ci zaszkodził czy też nie, przejdź do strony 'PODSUMUJ POSIŁKI' a następnie otwórz stronę dnia który chcesz podsumować.";
            InformationsL5.Text = " •  Jedyne co pozostało Ci zrobić to poustawiać odpowiednio przyciski przy produktach.";
            InformationsL6.Text = "I tak mamy do wyboru: ";
            InformationsL7.Text = "  -   Mogę - ustawiamy w przypadku kiedy jesteśmy pewni, że dany produkt nam nie szkodzi.";
            InformationsL8.Text = "  -   Nie mogę - odwrotnie jak w przypadku 'Mogę', klikamy kiedy jesteśmy pewni, że produkt nam zaszkodził.";
            InformationsL9.Text = "  -   Sprawdz jeszcze raz - przycisk używany jeżeli nie mamy pewności co do produktu.";
            InformationsL10.Text = " •  Na koniec klikamy strzałkę wstecz, po czym aplikacja zapyta Cię czy chcesz zapisać zmiany. Klikasz tak i gotowe.";
            InformationsL11.Text = " •  Przechodząc na stronę Mogę / Nie mogę masz dostęp do sprawdzenia listy produktów, które już spożyłeś i oznaczyłeś.";
            InformationsL12.Text = "  *   *   *   *   *   *   *   *   *   *   *   *   *   *   *   *   *   *  ";
            InformationsL13.Text = "W razie problemów czy też pomysłów na ulepszenie aplikacji prosimy o wysłanie wiadomości email korzystając z przycisku poniżej. Pozdrawiamy i życzymy wszystkim użytkownikom dużo zdrówka:)";
        }
	}
}