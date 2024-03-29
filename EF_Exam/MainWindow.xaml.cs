using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EF_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Collections Store = new();
        
        //Customer Customer;
        public MainWindow()
        {
            Login login = new Login(Store);
            login.ShowDialog();
            if (login.DialogResult == true)
            {
                InitializeComponent();
                Store.TotalCash = Store.Plates.Where(x => x.IsSold && x.SoldDate <= DateTime.Now).Sum(x => x.Price);
                if (cash_label != null)
                    cash_label.Content = Store.TotalCash + " $";
                //Customer = login.Customer;

                if (customers_data_grid != null)
                    customers_data_grid.ItemsSource = Store.Customers;

                if (prom_data_grid != null)
                    prom_data_grid.ItemsSource = Store.Promotions;

                if (data_grid != null)
                    data_grid.ItemsSource = Store.Plates;

                if (genre_combo_box != null)
                    genre_combo_box.ItemsSource = Store.Genres.Select(x => x.Name);

                if (popularity_box != null)
                {
                    List<string> popul = new() { "Popularity", "Day", "Week", "Month", "Year" };
                    popularity_box.ItemsSource = popul;
                }

                Loaded += (s, e) =>
                {
                    ColumnsClear();
                    genre_combo_box.SelectedIndex = 0;
                    popularity_box.SelectedIndex = 0;
                    popularity_box.SelectionChanged += (s, e) =>
                    {
                        string select = popularity_box.SelectedItem as string;
                        if (select == "Day")                                    // Беру только 5 популярнейших
                        {
                            var el = Store.Plates.Where(x => x.SoldDate?.Date == DateTime.Now.Date).OrderByDescending(x => x.SoldCount).Take(5).
                            GroupBy(x => x.GenreId);
                            if (el.Count() > 0)
                            {
                                Dictionary<string, int> gen_count = new();
                                foreach (var ee in el)
                                {
                                    string gen = Store.Genres.FirstOrDefault(x => x.Id == ee.Key).Name;
                                    gen_count.Add(gen, ee.Count());
                                }
                                data_grid.ItemsSource = gen_count.Select(x => new { GenreName = x.Key, SoldCopies = x.Value });
                            }
                            else
                                MessageBox.Show("No results");
                        }
                        if (select == "Week")
                        {
                            var el = Store.Plates.Where(x => x.SoldDate?.Date <= DateTime.Now.Date && x.SoldDate?.Date > DateTime.Now.AddDays(-7).Date).OrderByDescending(x => x.SoldCount).Take(5).
                            GroupBy(x => x.GenreId);
                            if (el.Count() > 0)
                            {
                                Dictionary<string, int> gen_count = new();
                                foreach (var ee in el)
                                {
                                    string gen = Store.Genres.FirstOrDefault(x => x.Id == ee.Key).Name;
                                    gen_count.Add(gen, ee.Count());
                                }
                                data_grid.ItemsSource = gen_count.Select(x => new { GenreName = x.Key, SoldCopies = x.Value });
                            }
                            else
                                MessageBox.Show("No results");
                        }
                        if (select == "Month")
                        {
                            var el = Store.Plates.Where(x => x.SoldDate?.Date <= DateTime.Now.Date && x.SoldDate?.Date > DateTime.Now.AddDays(-30).Date).OrderByDescending(x => x.SoldCount).Take(5).
                            GroupBy(x => x.GenreId);
                            if (el.Count() > 0)
                            {
                                Dictionary<string, int> gen_count = new();
                                foreach (var ee in el)
                                {
                                    string gen = Store.Genres.FirstOrDefault(x => x.Id == ee.Key).Name;
                                    gen_count.Add(gen, ee.Count());
                                }
                                data_grid.ItemsSource = gen_count.Select(x => new { GenreName = x.Key, SoldCopies = x.Value });
                            }
                            else
                                MessageBox.Show("No results");
                        }
                        if (select == "Year")
                        {
                            var el = Store.Plates.Where(x => x.SoldDate?.Date <= DateTime.Now.Date && x.SoldDate?.Date > DateTime.Now.AddDays(-365).Date).OrderByDescending(x => x.SoldCount).Take(5).
                            GroupBy(x => x.GenreId);
                            if (el.Count() > 0)
                            {
                                Dictionary<string, int> gen_count = new();
                                foreach (var ee in el)
                                {
                                    string gen = Store.Genres.FirstOrDefault(x => x.Id == ee.Key).Name;
                                    gen_count.Add(gen, ee.Count());
                                }
                                data_grid.ItemsSource = gen_count.Select(x => new { GenreName = x.Key, SoldCopies = x.Value });
                            }
                            else
                                MessageBox.Show("No results");
                        }
                    };
                };
            
            }
            else
                Close();
        }


        void ColumnsClear()
        {
            customers_data_grid.Columns[0].Visibility = Visibility.Hidden;
            customers_data_grid.Columns[5].Visibility = Visibility.Hidden;
            customers_data_grid.Columns[6].Visibility = Visibility.Hidden;

            prom_data_grid.Columns[0].Visibility = Visibility.Hidden;

            data_grid.Columns[0].Visibility = Visibility.Hidden;
            data_grid.Columns[4].Visibility = Visibility.Hidden;
            data_grid.Columns[6].Visibility = Visibility.Hidden;
            data_grid.Columns[8].Visibility = Visibility.Hidden;
            data_grid.Columns[9].Visibility = Visibility.Hidden;
            data_grid.Columns[13].Visibility = Visibility.Hidden;
        }

        private void all_plates_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                data_grid.ItemsSource = Store.Plates;
                ColumnsClear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save_changes_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data_grid.ItemsSource == Store.Plates)
                {
                    Store.SavePlatesChanges();
                    data_grid.ItemsSource = Store.Plates;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        void RecountCustomerMoney(Customer customer)
        {
            try
            {
                if (customer.SpentMoney >= 300 && customer.SpentMoney < 650)
                    customer.DiscountPercent = 5;
                else if (customer.SpentMoney >= 650 && customer.SpentMoney < 1000)
                    customer.DiscountPercent = 10;
                else if (customer.SpentMoney >= 1000)
                    customer.DiscountPercent = 15;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sell_the_plate_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data_grid.SelectedItem != null && customers_data_grid.SelectedItem != null)
                {
                    Plate plate = data_grid.SelectedItem as Plate;
                    Customer customer = customers_data_grid.SelectedItem as Customer;
                    if (customer != null && plate != null)
                    {
                        var pl = Store.Plates.FirstOrDefault(x => x.Id == plate.Id);
                        if (pl == null)
                            pl = Store.ScrappedPlates.FirstOrDefault(x => x.Id == plate.Id);
                        if (pl.IsSold || pl.Price == 0)
                        {
                            MessageBox.Show("Selected plate is already sold, reserved, or scrapped, select another plate");
                        }
                        else
                        {
                            var cus = Store.Customers.FirstOrDefault(x => x.Id == customer.Id);
                            pl.IsSold = true;
                            pl.SoldCount += 1;
                            pl.SoldDate = DateTime.Now;
                            Store.TotalCash += pl.Price * (1m - (cus.DiscountPercent/100.0m));
                            cash_label.Content = Store.TotalCash + " $";
                            pl.CustomerId = cus.Id;
                            cus.SpentMoney += pl.Price;
                            RecountCustomerMoney(cus);
                            customers_data_grid.Items.Refresh();
                            data_grid.ItemsSource = null;
                            data_grid.ItemsSource = Store.SoldPlates;
                            ColumnsClear();
                            Store.SoldPlates.Add(pl);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select some plate and customer");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void unsold_plates_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                data_grid.ItemsSource = Store.SoldPlates;
                ColumnsClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void unsold_pl_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                data_grid.ItemsSource = Store.Plates.Where(x => !x.IsSold);
                ColumnsClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void scrap_plate_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data_grid.SelectedItem != null)
                {
                    Plate plate = data_grid.SelectedItem as Plate;
                    if (plate != null)
                    {
                        var pl = Store.Plates.FirstOrDefault(x => x.Id == plate.Id);
                        if(!pl.IsSold)
                        {
                            pl.Price = 0;
                            Store.ScrappedPlates.Add(pl);
                            Store.Plates.Remove(pl);
                        }
                        else
                        {
                            MessageBox.Show("You can`t scrap the sold plate");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select some plate first");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void show_scrapped_plates_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                data_grid.ItemsSource = Store.ScrappedPlates;
                data_grid.Columns[0].Visibility = Visibility.Hidden;
                data_grid.Columns[4].Visibility = Visibility.Hidden;
                data_grid.Columns[6].Visibility = Visibility.Hidden;
                data_grid.Columns[8].Visibility = Visibility.Hidden;
                data_grid.Columns[13].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void apply_promotion_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (prom_data_grid.SelectedItem != null)
                {
                    Promotion prom = prom_data_grid.SelectedItem as Promotion;
                    if (prom != null)
                    {
                        string name = prom.Name.Substring("Week of".Length).Trim();
                        int genreid = Store.Genres.FirstOrDefault(y => y.Name.Contains(name)).Id;
                        if (!Store.GenreId_Discount.ContainsKey(genreid))
                        {
                            var plates = Store.Plates.Where(x => x.GenreId == genreid);
                            Store.GenreId_Discount.Add(genreid, prom.PromotionDiscount);
                            foreach (Plate pl in plates)
                            {
                                pl.Price = Math.Round(pl.Price * (1m - (decimal)prom.PromotionDiscount / 100), 2);
                            }
                            data_grid.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("The promotion was already applyed to this genre");
                        }
                    }
                }
                else
                    MessageBox.Show("Select the promotion first");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void abadon_promotion_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (prom_data_grid.SelectedItem != null)
                {
                    Promotion prom = prom_data_grid.SelectedItem as Promotion;
                    if (prom != null)
                    {
                        string name = prom.Name.Substring("Week of".Length).Trim();
                        int genreid = Store.Genres.FirstOrDefault(y => y.Name.Contains(name)).Id;
                        if (Store.GenreId_Discount.ContainsKey(genreid))
                        {
                            var plates = Store.Plates.Where(x => x.GenreId == genreid);
                            foreach (var pl in plates)
                            {
                                pl.Price = Math.Round(pl.Price * (1m + (decimal)prom.PromotionDiscount/100));
                            }
                            data_grid.Items.Refresh();
                            Store.GenreId_Discount.Remove(genreid);
                        }
                        else
                            MessageBox.Show("This promotion hasn`t been applied yet");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void book_the_plate_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data_grid.SelectedItem != null && customers_data_grid.SelectedItem != null && picker.SelectedDate.HasValue)
                {
                    Plate plate = data_grid.SelectedItem as Plate;
                    Customer customer = customers_data_grid.SelectedItem as Customer;
                    DateTime date = picker.SelectedDate.Value;

                    var pl = Store.Plates.FirstOrDefault(x => x.Id == plate.Id);
                    if (pl == null)
                        pl = Store.ScrappedPlates.FirstOrDefault(x => x.Id == plate.Id);
                    if (pl.IsSold || pl.Price == 0)
                    {
                        MessageBox.Show("Selected plate is already sold, reserved, or scrapped, select another plate");
                    }
                    else
                    {
                        var cus = Store.Customers.FirstOrDefault(x => x.Id == customer.Id);
                        pl.IsSold = true;
                        pl.SoldCount += 1;
                        pl.SoldDate = date;
                        pl.CustomerId = cus.Id;
                        MessageBox.Show($"The plate {pl.Name} was booked by {cus.FirstName} {cus.LastName} for {date}");
                        data_grid.ItemsSource = null;
                        data_grid.ItemsSource = Store.SoldPlates;
                        ColumnsClear();
                        Store.SoldPlates.Add(pl);
                    }
                }
                else
                    MessageBox.Show("You didn`t select the plate, customer or date to book");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void focus_box(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)sender;
                if (tb != null)
                {
                    tb.Foreground = Brushes.Black;
                    tb.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void name_pl_search(object sender, RoutedEventArgs e)
        {
            try
            {
                Button but = (Button)sender;
                if (but.Content.ToString().Contains("Name"))
                {
                    if (name_box.Text.Length > 2)
                    {
                        var plates = Store.Plates.Where(x => x.Name.Trim().ToLower().Contains(name_box.Text.Trim().ToLower()));
                        data_grid.ItemsSource = plates;
                        ColumnsClear();
                    }
                    else
                    {
                        data_grid.ItemsSource = Store.Plates;
                        ColumnsClear();
                    }
                }
                else
                {
                    if (band_box.Text.Length > 2)
                    {
                        Band band = Store.Bands.FirstOrDefault(x => x.Name.Trim().ToLower().Contains(band_box.Text.Trim().ToLower()));
                        if (band == null)
                        {
                            MessageBox.Show("No results");
                        }
                        else
                        {
                            MessageBox.Show($"The band name is {band.Name}");
                            var plates = Store.Plates.Where(x => x.BandId == band.Id);
                            data_grid.ItemsSource = plates;
                            ColumnsClear();
                        }
                    }
                    else
                    {
                        data_grid.ItemsSource = Store.Plates;
                        ColumnsClear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void genre_search(object sender, RoutedEventArgs e)
        {
            try
            {
                string genre = genre_combo_box.SelectedItem.ToString();
                Genre gen = Store.Genres.FirstOrDefault(x => x.Name == genre);
                if (gen != null)
                {
                    data_grid.ItemsSource = Store.Plates.Where(x => x.GenreId == gen.Id);
                    ColumnsClear();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void play_song_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data_grid.SelectedItem != null)
                {
                    Plate plate = data_grid.SelectedItem as Plate;
                    if (plate.MusicFolder != null)
                    {
                        Store.songs = Directory.GetFiles(plate.MusicFolder, "*mp3");
                        Store.song_index = 0;
                        Store.player.Open(new Uri(Store.songs[Store.song_index], UriKind.Relative));
                        Store.player.Play();
                    }
                    else
                        MessageBox.Show("This plate doesn`t support music preview!");
                }
                else
                {
                    MessageBox.Show("Select some plate first");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void select_ev(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (data_grid.SelectedItem != null)
                {
                    Plate plate = data_grid.SelectedItem as Plate;
                    if (plate.MusicFolder != null)
                    {
                        play_border.Opacity = 1;
                        prev_border.Opacity = 1;
                        next_border.Opacity = 1;
                        stop_border.Opacity = 1;
                    }
                    else
                    {
                        play_border.Opacity = 0.5;
                        prev_border.Opacity = 0.5;
                        next_border.Opacity = 0.5;
                        stop_border.Opacity = 0.5;
                    }
                }
                else
                {
                    play_border.Opacity = 0.5;
                    prev_border.Opacity = 0.5;
                    next_border.Opacity = 0.5;
                    stop_border.Opacity = 0.5;
                }
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void prev_song_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data_grid.SelectedItem != null)
                {
                    Plate plate = data_grid.SelectedItem as Plate;
                    if (plate.MusicFolder != null)
                    {
                        Store.player.Stop();
                        if (Store.song_index == 0)
                            Store.song_index = Store.songs.Length - 1;
                        else
                            Store.song_index--;
                        Store.player.Open(new Uri(Store.songs[Store.song_index], UriKind.Relative));
                        Store.player.Play();
                    }
                    else
                        MessageBox.Show("This plate doesn`t support music preview!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void next_song_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data_grid.SelectedItem != null)
                {
                    Plate plate = data_grid.SelectedItem as Plate;
                    if (plate.MusicFolder != null)
                    {
                        Store.player.Stop();
                        if (Store.song_index == Store.songs.Length - 1)
                            Store.song_index = 0;
                        else
                            Store.song_index++;
                        Store.player.Open(new Uri(Store.songs[Store.song_index], UriKind.Relative));
                        Store.player.Play();
                    }
                    else
                        MessageBox.Show("This plate doesn`t support music preview!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stop_song_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                Store.player.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}