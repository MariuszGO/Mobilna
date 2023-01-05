using System.Data.SQLite;
namespace Mobilna;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}
    /*
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

       
        SemanticScreenReader.Announce(CounterBtn.Text);
	}
    */
    private void Sumowanie(object sender, EventArgs e)
    {
        int aa = int.Parse(a.Text);
        int bb = int.Parse(b.Text);
        int cc = aa + bb;


        c.Text = cc.ToString();

    }

    private void Losowanie(object sender, EventArgs e)
    {
        int n=0;
        int aa=0, bb=0;
        bool czy_liczba= int.TryParse(a.Text, out n) && int.TryParse(b.Text, out n);

        if (czy_liczba)
        {
            aa = int.Parse(a.Text);
            bb = int.Parse(b.Text);
        }
        else
        {
            
            DisplayAlert("Błąd!!!", "Wprowadziłeś niepoprawną wartość!!!", "OK");
            
            return;
        }



        int wylosowana;

        Random liczba = new Random();

        if (aa > bb)
        {
            int tmp;
            tmp = aa;
            aa = bb;
            bb= tmp;
        }
        
        wylosowana = liczba.Next(aa, bb+1);
        c.Text = wylosowana.ToString();

        string conection_string= "Data Source=baza.db";
        SQLiteConnection con = new SQLiteConnection(conection_string);
        
        con.Open();

        string sql;
        sql = "INSERT INTO"

    }


    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = entry.Text;

        lbl.Text = entry.Text;

    }
        void OnEntryCompleted(object sender, EventArgs e)
    {

        string text = ((Entry)sender).Text;
        lbl1.Text = entry.Text;



    }

}

