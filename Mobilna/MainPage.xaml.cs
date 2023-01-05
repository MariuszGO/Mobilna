using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
namespace Mobilna;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}
 
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

        string conection_string= "Data Source=C:\\Users\\mariu\\Source\\Repos\\MariuszGO\\Mobilna\\Mobilna\\baza.db;Version=3;";
        SQLiteConnection con = new SQLiteConnection(conection_string);


        try
        {
            con.Open();
        }
        catch (Exception ex)
        {

        }
       // return con;
    



 

        string sql;
       


    SQLiteCommand sqlite_cmd;
    sqlite_cmd = con.CreateCommand();
         sqlite_cmd.CommandText = "INSERT INTO losowanie (liczba) VALUES(" + wylosowana + ");";
         sqlite_cmd.ExecuteNonQuery();

        con.Close();

    }

    /*READ
     
      static void ReadData(SQLiteConnection conn)
      {
         SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

         sqlite_datareader = sqlite_cmd.ExecuteReader();
         while (sqlite_datareader.Read())
         {
            string myreader = sqlite_datareader.GetString(0);
            Console.WriteLine(myreader);
         }
         conn.Close();
      }



    */


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

