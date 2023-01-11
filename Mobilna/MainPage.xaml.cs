using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;


namespace Mobilna;

public partial class MainPage : ContentPage
{

    string plik = "C:\\Users\\mariu\\source\\repos\\Mobilna\\Mobilna\\baza1.db";


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
        //string path = Directory.GetCurrentDirectory();
     

        if (!File.Exists(plik))
        {

            SQLiteConnection.CreateFile(plik);

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + plik + ";Version=3;");
            m_dbConnection.Open();

            string sql = "create table losowanie (liczba int)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

           m_dbConnection.Close();


        }


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
    
        string conection_string= "Data Source=" + plik + ";Version=3;";
        SQLiteConnection con = new SQLiteConnection(conection_string);


        try
        {
            con.Open();
        }
        catch (Exception ex)
        {

        }
       // return con;
    



 

       
       


    SQLiteCommand sqlite_cmd;
    sqlite_cmd = con.CreateCommand();
         sqlite_cmd.CommandText = "INSERT INTO losowanie (liczba) VALUES(" + wylosowana + ");";
         sqlite_cmd.ExecuteNonQuery();

        con.Close();


        try
        {
            con.Open();
        }
        catch (Exception ex)
        {

        }



        SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd1;
         sqlite_cmd1 = con.CreateCommand();
         sqlite_cmd1.CommandText = "SELECT liczba FROM losowanie";
        baza.Text = " ";
         sqlite_datareader = sqlite_cmd1.ExecuteReader();
         while (sqlite_datareader.Read())
         {
            int myreader = sqlite_datareader.GetInt32(0);
            baza.Text += myreader.ToString() + " ";

        }

    
        con.Close();
      
    
    }


    private void usunn(object sender, EventArgs e) {

        string conection_string = "Data Source=" + plik + ";Version=3;";
        SQLiteConnection con = new SQLiteConnection(conection_string);


        try
        {
            con.Open();
        }
        catch (Exception ex)
        {

        }



        SQLiteCommand sqlite_cmd;
        sqlite_cmd = con.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM LOSOWANIE";
        sqlite_cmd.ExecuteNonQuery();

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

