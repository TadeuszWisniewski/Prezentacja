using GalaSoft.MvvmLight.Messaging;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TDAUTadeuszWisniewskiProjekt.Helpers;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region CommandsMenu
        //ta komenda zostanie podpięta pod pasek narzędzi i menu górne
        public ICommand TowarCommand
        {
            get
            {
                return new BaseCommand(CreateTowar);
            }
        }
        public ICommand TowaryCommand
        {
            get
            {
                return new BaseCommand(ShowAllTowar);
            }
        }
        public ICommand PracownikCommand
        {
            get
            {
                return new BaseCommand(CreatePracownik);
            }
        }
        public ICommand PracownicyCommand
        {
            get
            {
                return new BaseCommand(ShowAllPracownicy);
            }
        }
        public ICommand FakturaCommand
        {
            get
            {
                return new BaseCommand(CreateFaktura);
            }
        }
        public ICommand FakturyCommand
        {
            get
            {
                return new BaseCommand(ShowAllFaktury);
            }
        }
        public ICommand KontrahentCommand
        {
            get
            {
                return new BaseCommand(CreateKontrahent);
            }
        }
        public ICommand WymiarEtatuCommand
        {
            get
            {
                return new BaseCommand(CreateWymiarEtatu);
            }
        }
        public ICommand WymiaryEtatuCommand
        {
            get
            {
                return new BaseCommand(ShowAllWymiarEtatu);
            }
        }
        public ICommand WojewodztwoCommand
        {
            get
            {
                return new BaseCommand(CreateWojewodztwo);
            }
        }
        public ICommand WojewodztwaCommand
        {
            get
            {
                return new BaseCommand(ShowAllWojewodztwo);
            }
        }
        public ICommand WalutaCommand
        {
            get
            {
                return new BaseCommand(CreateWaluta);
            }
        }
        public ICommand WalutyCommand
        {
            get
            {
                return new BaseCommand(ShowAllWaluta);
            }
        }
        public ICommand TypUmowyOPraceCommand
        {
            get
            {
                return new BaseCommand(CreateTypUmowyOPrace);
            }
        }
        public ICommand TypyUmowOPraceCommand
        {
            get
            {
                return new BaseCommand(ShowAllTypUmowyOPrace);
            }
        }
        public ICommand TypStawkiCommand
        {
            get
            {
                return new BaseCommand(CreateTypStawki);
            }
        }
        public ICommand TypyStawkiCommand
        {
            get
            {
                return new BaseCommand(ShowAllTypStawki);
            }
        }
        public ICommand TypNIPCommand
        {
            get
            {
                return new BaseCommand(CreateTypNIP);
            }
        }
        public ICommand TypyNIPCommand
        {
            get
            {
                return new BaseCommand(ShowAllTypNIP);
            }
        }
        public ICommand TypCommand
        {
            get
            {
                return new BaseCommand(CreateTyp);
            }
        }
        public ICommand TypyCommand
        {
            get
            {
                return new BaseCommand(ShowAllTyp);
            }
        }
        public ICommand StatusWBazieCommand
        {
            get
            {
                return new BaseCommand(CreateStatusWBazieDanych);
            }
        }
        public ICommand StatusyWBazieCommand
        {
            get
            {
                return new BaseCommand(ShowAllStatusWBazieDanych);
            }
        }
        public ICommand StatusCommand
        {
            get
            {
                return new BaseCommand(CreateStatus);
            }
        }
        public ICommand StatusyCommand
        {
            get
            {
                return new BaseCommand(ShowAllStatusy);
            }
        }
        public ICommand StanowiskoCommand
        {
            get
            {
                return new BaseCommand(CreateStanowisko);
            }
        }
        public ICommand StanowiskaCommand
        {
            get
            {
                return new BaseCommand(ShowAllStanowiska);
            }
        }
        public ICommand RodzajVATCommand
        {
            get
            {
                return new BaseCommand(CreateRodzajVAT);
            }
        }
        public ICommand RodzajeVATCommand
        {
            get
            {
                return new BaseCommand(ShowAllRodzajeVAT);
            }
        }
      
        public ICommand PodstawaZatrudnieniaCommand
        {
            get
            {
                return new BaseCommand(CreatePodstawaZatrudnienia);
            }
        }
        public ICommand PodstawyZatrudnieniaCommand
        {
            get
            {
                return new BaseCommand(ShowAllPodstawyZatrudnenia);
            }
        }
        public ICommand MiejscowoscCommand
        {
            get
            {
                return new BaseCommand(CreateMiejscowosc);
            }
        }
        public ICommand MiejscowosciCommand
        {
            get
            {
                return new BaseCommand(ShowAllMiejscowosci);
            }
        }
        public ICommand KrajCommand
        {
            get
            {
                return new BaseCommand(CreateKraj);
            }
        }
        public ICommand KrajeCommand
        {
            get
            {
                return new BaseCommand(ShowAllKraje);
            }
        }
        public ICommand KodCPVCommand
        {
            get
            {
                return new BaseCommand(CreateKodCPV);
            }
        }
        public ICommand KodyCPVCommand
        {
            get
            {
                return new BaseCommand(ShowAllKodyCPV);
            }
        }
        public ICommand JednostkaOrganizacyjnaCommand
        {
            get
            {
                return new BaseCommand(CreateJednostkaOrganizacyjna);
            }
        }
        public ICommand JednostkiOrganizacyjneCommand
        {
            get
            {
                return new BaseCommand(ShowAllJednostkaOrganizacyjna);
            }
        }
        public ICommand JednostkaCommand
        {
            get
            {
                return new BaseCommand(CreateJednostka);
            }
        }
        public ICommand JednostkiCommand
        {
            get
            {
                return new BaseCommand(ShowAllJednostka);
            }
        }
        public ICommand FormaPrawnaCommand
        {
            get
            {
                return new BaseCommand(CreateFormaPrawna);
            }
        }
        public ICommand FormyPrawneCommand
        {
            get
            {
                return new BaseCommand(ShowAllFormaPrawna);
            }
        }
        public ICommand EANTypCommand
        {
            get
            {
                return new BaseCommand(CreateEANTyp);
            }
        }
        public ICommand EANTypyCommand
        {
            get
            {
                return new BaseCommand(ShowAllEANTyp);
            }
        }
        public ICommand DefinicjaPlatnosciCommand
        {
            get
            {
                return new BaseCommand(CreateDefinicjaPlatnosci);
            }
        }
        public ICommand DefinicjePlatnosciCommand
        {
            get
            {
                return new BaseCommand(ShowAllDefinicjePlatnosci);
            }
        }
        public ICommand CenaCommand
        {
            get
            {
                return new BaseCommand(CreateCena);
            }
        }
        public ICommand CenyCommand
        {
            get
            {
                return new BaseCommand(ShowAllCeny);
            }
        }
        public ICommand AdresyDoKorespondencjiCommand
        {
            get
            {
                return new BaseCommand(ShowAllAdresyDoKorespondencji);
            }
        }
        public ICommand AdresZameldowaniaCommand
        {
            get
            {
                return new BaseCommand(CreateAdresZameldowania);
            }
        }
        
        public ICommand AdresyZameldowaniaCommand
        {
            get
            {
                return new BaseCommand(ShowAllAdresyZameldowania);
            }
        }  
        public ICommand MiejsceUrodzeniaCommand
        {
            get
            {
                return new BaseCommand(CreateMiejsceUrodzenia);
            }
        }
        public ICommand MiejscaUrodzeniaCommand
        {
            get
            {
                return new BaseCommand(ShowAllMiejscaUrodzenia);
            }
        } 
        public ICommand KontrahenciCommand
        {
            get
            {
                return new BaseCommand(ShowAllKontrahenci);
            }
        }
        #endregion


        //Okno glowne zawiera kolekcje linkow (command view modeli) oraz kolekcje zakladek (workspace view modeli)
        #region Commands
        private ReadOnlyCollection<CommandViewModel> _Commands;
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    // tworze liste linkow z lewej strony, wypelniam ja i przypisuje do readonlyCollection
                    List<CommandViewModel> cmds = CreateCommands(); // lista linkow utworzy sie za pomoca funkcji create commands
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }

        private List<CommandViewModel> CreateCommands()
        {
            //ten messenger złapie wiadomość o otworzeniu nowego okna
            //jak messenger złapie stringa który będzie zawierał: polecenie otwarcia okna to wywoła metodę open.
            Messenger.Default.Register<string>(this, open);
            //tworze liste command view modeli
            return new List<CommandViewModel>
            {
                // tu decydue jakie linki beda po lewej stronie (nazwy tych linkow i jakie funkcje wywoluja)
                new CommandViewModel("Towar",new BaseCommand(CreateTowar)),
                new CommandViewModel("Towary",new BaseCommand(ShowAllTowar)),
                //Komentuje do czasu implementacji
                //new CommandViewModel("Pracownik",new BaseCommand(CreatePracownik)),
                //new CommandViewModel("Pracownicy",new BaseCommand(ShowAllPracownicy)),
                new CommandViewModel("Faktura",new BaseCommand(CreateFaktura)),
                new CommandViewModel("Faktury",new BaseCommand(ShowAllFaktury)),
                new CommandViewModel("Kontrahent",new BaseCommand(CreateKontrahent)),
                new CommandViewModel("Kontrahenci",new BaseCommand(ShowAllKontrahenci)),

            };
        }
        private void open(string name)
        {
            if (name == "TowaryAdd")
            {
                CreateTowar();
            }
            if (name == "TowaryShow")
            {
                ShowAllTowar();
            }
            if (name == "FakturyAdd")
            {
                CreateFaktura();
            }
            //if (name == "PracownicyAdd")
            //{
            //    CreatePracownik();
            //}
            if (name == "KontrahenciShow")
            {
                ShowAllKontrahenci();
            }
            if (name == "Typy umów o praceShow")
            {
                ShowAllTypUmowyOPrace();
            }
            if(name == "Typy umowy o praceAdd")
            {
                CreateTypUmowyOPrace();
            }    
            if (name == "KontrahenciAdd")
            {
                CreateKontrahent();
            }
            if (name == "Adresy do korespondencjiShow")
            {
                ShowAllAdresyDoKorespondencji();
            }
            if (name == "Adresy zameldowaniaAdd")
            {
                CreateAdresZameldowania();
            }
            if (name == "AdresyShow")
            {
                ShowAllAdresyZameldowania();
            }
            if (name == "CenyAdd")
            {
                CreateCena();
            }
            if (name == "CenyShow")
            {
                ShowAllCeny();
            }
            if (name == "Ceny wyprzedazyShow")
            {
                ShowAllCenyWyprzedazy();
            }
            if (name == "Definicje platnosciAdd")
            {
                CreateDefinicjaPlatnosci();
            }
            if (name == "Definicje platnosciShow")
            {
                ShowAllDefinicjePlatnosci();
            }
            if (name == "Formy prawneAdd")
            {
                CreateFormaPrawna();
            }
            if (name == "Formy prawneShow")
            {
                ShowAllFormaPrawna();
            }
            if (name == "Jednostki organizacyjneAdd")
            {
                CreateJednostkaOrganizacyjna();
            }
            if (name == "Jednostki organizacyjneShow")
            {
                ShowAllJednostkaOrganizacyjna();
            }
            if (name == "JednostkiAdd")
            {
                CreateJednostka();
            }
            if (name == "JednostkiShow")
            {
                ShowAllJednostka();
            }
            if (name == "Kody CPVAdd")
            {
                CreateKodCPV();
            }
            if (name == "CPVShow")
            {
                ShowAllKodyCPV();
            }
            if (name == "KrajeAdd")
            {
                CreateKraj();
            }
            if (name == "KrajeShow")
            {
                ShowAllKraje();
            }
            if (name == "Miejsca urodzeniaAdd")
            {
                CreateMiejsceUrodzenia();
            }
            if (name == "Miejsca urodzeniaShow")
            {
                ShowAllMiejscaUrodzenia();
            }
            if (name == "MiejscowosciAdd")
            {
                CreateMiejscowosc();
            }
            if (name == "MiejscowosciShow")
            {
                ShowAllMiejscowosci();
            }
            if (name == "Podstawy zatrudnieniaAdd")
            {
                CreatePodstawaZatrudnienia();
            }
            if (name == "Podstawy zatrudnieniaShow")
            {
                ShowAllPodstawyZatrudnenia();
            }
            if (name == "Rodzaje VATAdd")
            {
                CreateRodzajVAT();
            }
            if (name == "Rodzaje VATShow")
            {
                ShowAllRodzajeVAT();
            }
            if (name == "Rodzaje VAT zakupuShow")
            {
                ShowAllRodzajeVatZakupu();
            }
            if (name == "StanowiskaAdd")
            {
                CreateStanowisko();
            }
            if (name == "StanowiskaShow")
            {
                ShowAllStanowiska();
            }
            if (name == "StatusyAdd")
            {
                CreateStatus();
            }
            if (name == "StatusyShow")
            {
                ShowAllStatusy();
            }
            if (name == "Statusy w bazieAdd")
            {
                CreateStatusWBazieDanych();
            }
            if (name == "Statusy w bazieShow")
            {
                ShowAllStatusWBazieDanych();
            }
            if (name == "Statusy w bazie VIESShow")
            {
                ShowAllStatusWBazieVIES();
            }
            if (name == "EAN TypyAdd")
            {
                CreateEANTyp();
            }
            if (name == "Typy NIPAdd")
            {
                CreateTypNIP();
            }
            if (name == "Typy stawkiAdd")
            {
                CreateTypStawki();
            }
            if (name == "Typy stawekShow")
            {
                ShowAllTypStawki();
            }
            if (name == "TypyAdd")
            {
                CreateTyp();
            }
            if (name == "TypyShow")
            {
                ShowAllTyp();
            }
            if (name == "WalutyAdd")
            {
                CreateWaluta();
            }
            if (name == "WojewodztwaAdd")
            {
                CreateWojewodztwo();
            }
            if (name == "WojewodztwaShow")
            {
                ShowAllWojewodztwo();
            }
            if (name == "Wymiary etatuAdd")
            {
                CreateWymiarEtatu();
            }
            if (name == "Wymiar etatuShow")
            {
                ShowAllWymiarEtatu();
            }
        }
        #endregion

        #region Workspaces
        private ObservableCollection<WorkspaceViewModel> _Workspaces; // to jest kolekcja zakladek
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;

                }
                return _Workspaces;
            }
        }

        #endregion

        #region Zakładki
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region  Funkcje wywolujace zakladki
        private void CreateTowar()
        {
            // Najpierw tworze nowy workspace 
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            // Nowy workspace dodaje do kolekcji workspacow (zakladeK)
            Workspaces.Add(workspace);
            // wlaczamy aktywnosc dodanej zakladki
            SetActiveWorkspace(workspace);
        }
        //przy tworzeniu towaru za kazdym razem tworze nowa zakladke
        //przy wyswietlaniu najpierw sprawdzam czy zakladka wyswietlajaca wszystkie towary juz jest otwarta
        //jezeli nie to ja tworze a jezeli tak to przywracam jej widocznosc
        private void ShowAllTowar()
        {
            //najpierw sprawdzamy czy zakladka wyswietlajaca wszystkie towary juz jest w kolekcji zakladek
            WszystkieTowaryViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;
            //jezeli takiej zakladki brak to tworzymy ja
            if (workspace == null)
            {
                //jezeli jej nie ma to tworze nowa i dodaje ja do kolekcji
                workspace = new WszystkieTowaryViewModel();
                Workspaces.Add(workspace);
            }
            // istniejaca zakladke lub nowa ustawiam na aktywna
            SetActiveWorkspace(workspace);
        }
        private void CreatePracownik()
        {
            NowyPracownikViewModel workspace = new NowyPracownikViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllPracownicy()
        {
            WszyscyPracownicyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel) as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllFaktury()
        {
            WszystkieFakturyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateKontrahent()
        {
            NowyKontrahentViewModel workspace = new NowyKontrahentViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void CreateWymiarEtatu()
        {
            NowyWymiarEtatuViewModel workspace = new NowyWymiarEtatuViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllWymiarEtatu()
        {
            WszystkieWymiaryEtatuViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieWymiaryEtatuViewModel) as WszystkieWymiaryEtatuViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieWymiaryEtatuViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateWojewodztwo()
        {
            NoweWojewodztwoViewModel workspace = new NoweWojewodztwoViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllWojewodztwo()
        {
            WszystkieWojewodztwaViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieWojewodztwaViewModel) as WszystkieWojewodztwaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieWojewodztwaViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateWaluta()
        {
            NowaWalutaViewModel workspace = new NowaWalutaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllWaluta()
        {
            WszystkieWalutyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieWalutyViewModel) as WszystkieWalutyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieWalutyViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateTypUmowyOPrace()
        {
            NowyTypUmowyOPraceViewModel workspace = new NowyTypUmowyOPraceViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllTypUmowyOPrace()
        {
            WszystkieTypyUmowOPraceViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieTypyUmowOPraceViewModel) as WszystkieTypyUmowOPraceViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyUmowOPraceViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateTypStawki()
        {
            NowyTypStawkiViewModel workspace = new NowyTypStawkiViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllTypStawki()
        {
            WszystkieTypyStawkiViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieTypyStawkiViewModel) as WszystkieTypyStawkiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyStawkiViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateTypNIP()
        {
            NowyTypNIPViewModel workspace = new NowyTypNIPViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllTypNIP()
        {
            WszystkieTypyNIPViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieTypyNIPViewModel) as WszystkieTypyNIPViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyNIPViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateTyp()
        {
            NowyTypViewModel workspace = new NowyTypViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllTyp()
        {
            WszystkieTypyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieTypyViewModel) as WszystkieTypyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateStatusWBazieDanych()
        {
            NowyStatusWBazieViewModel workspace = new NowyStatusWBazieViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllStatusWBazieDanych()
        {
            WszystkieStatusyWBazieViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyWBazieViewModel) as WszystkieStatusyWBazieViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyWBazieViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void ShowAllStatusWBazieVIES()
        {
            WszystkieStatusyWBazieVIESViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyWBazieVIESViewModel) as WszystkieStatusyWBazieVIESViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyWBazieVIESViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateStatus()
        {
            NowyStatusViewModel workspace = new NowyStatusViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllStatusy()
        {
            WszystkieStatusyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyViewModel) as WszystkieStatusyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateStanowisko()
        {
            NoweStanowiskoViewModel workspace = new NoweStanowiskoViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllStanowiska()
        {
            WszystkieStanowiskaViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieStanowiskaViewModel) as WszystkieStanowiskaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStanowiskaViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateRodzajVAT()
        {
            NowyRodzajVATViewModel workspace = new NowyRodzajVATViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllRodzajeVAT()
        {
            WszystkieRodzajeVATViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeVATViewModel) as WszystkieRodzajeVATViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeVATViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void ShowAllRodzajeVatZakupu()
        {
            WszystkieRodzajeVATZakupuViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeVATZakupuViewModel) as WszystkieRodzajeVATZakupuViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeVATZakupuViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreatePodstawaZatrudnienia()
        {
            NowaPodstawaZatrudnieniaViewModel workspace = new NowaPodstawaZatrudnieniaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllPodstawyZatrudnenia()
        {
            WszystkiePodstawyZatrudnieniaViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkiePodstawyZatrudnieniaViewModel) as WszystkiePodstawyZatrudnieniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePodstawyZatrudnieniaViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateKraj()
        {
            NowyKrajViewModel workspace = new NowyKrajViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllKraje()
        {
            WszystkieKrajeViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieKrajeViewModel) as WszystkieKrajeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKrajeViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateMiejscowosc()
        {
            NowyMiejscowoscViewModel workspace = new NowyMiejscowoscViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllMiejscowosci()
        {
            WszystkieMiejscowosciViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieMiejscowosciViewModel) as WszystkieMiejscowosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieMiejscowosciViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateKodCPV()
        {
            NowyKodCPVViewModel workspace = new NowyKodCPVViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllKodyCPV()
        {
            WszystkieKodyCPVViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieKodyCPVViewModel) as WszystkieKodyCPVViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKodyCPVViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateJednostkaOrganizacyjna()
        {
            NowaJednostkaOrganizacyjnaViewModel workspace = new NowaJednostkaOrganizacyjnaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllJednostkaOrganizacyjna()
        {
            WszystkieJednostkiOrganizacyjneViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieJednostkiOrganizacyjneViewModel) as WszystkieJednostkiOrganizacyjneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieJednostkiOrganizacyjneViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateJednostka()
        {
            NowaJednostkaViewModel workspace = new NowaJednostkaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllJednostka()
        {
            WszystkieJednostkiViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieJednostkiViewModel) as WszystkieJednostkiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieJednostkiViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateFormaPrawna()
        {
            NowaFormaPrawnaViewModel workspace = new NowaFormaPrawnaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllFormaPrawna()
        {
            WszystkieFormyPrawneViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieFormyPrawneViewModel) as WszystkieFormyPrawneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFormyPrawneViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateEANTyp()
        {
            NowyEANTypViewModel workspace = new NowyEANTypViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllEANTyp()
        {
            WszystkieTypyEANViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieTypyEANViewModel) as WszystkieTypyEANViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyEANViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateDefinicjaPlatnosci()
        {
            NowaDefinicjaPlatnosciViewModel workspace = new NowaDefinicjaPlatnosciViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllDefinicjePlatnosci()
        {
            WszystkieDefinicjePlatnosciViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieDefinicjePlatnosciViewModel) as WszystkieDefinicjePlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieDefinicjePlatnosciViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateCena()
        {
            NowaCenaViewModel workspace = new NowaCenaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllCeny()
        {
            WszystkieCenyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieCenyViewModel) as WszystkieCenyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieCenyViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void ShowAllCenyWyprzedazy()
        {
            WszystkieCenyWyprzedazyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieCenyWyprzedazyViewModel) as WszystkieCenyWyprzedazyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieCenyWyprzedazyViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void ShowAllAdresyDoKorespondencji()
        {
            WszystkieAdresyDoKorespondencjiViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyDoKorespondencjiViewModel) as WszystkieAdresyDoKorespondencjiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyDoKorespondencjiViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateAdresZameldowania()
        {
            NowyAdresZameldowaniaViewModel workspace = new NowyAdresZameldowaniaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllAdresyZameldowania()
        {
            WszystkieAdresyZameldowaniaViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyZameldowaniaViewModel) as WszystkieAdresyZameldowaniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyZameldowaniaViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void CreateMiejsceUrodzenia()
        {
            NoweMiejsceUrodzeniaViewModel workspace = new NoweMiejsceUrodzeniaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        private void ShowAllMiejscaUrodzenia()
        {
            WszystkieMiejscaUrodzeniaViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieMiejscaUrodzeniaViewModel) as WszystkieMiejscaUrodzeniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieMiejscaUrodzeniaViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void ShowAllKontrahenci()
        {
            WszyscyKontrahenciViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszyscyKontrahenciViewModel) as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
