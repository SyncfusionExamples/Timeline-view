using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TimelineView
{
    public class EventsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// list of meeting
        /// </summary>
        private ObservableCollection<Event> events;

        /// <summary>
        /// list of meeting
        /// </summary>
        private ObservableCollection<DayOfWeek> nonWorkingDays;

        /// <summary>
        /// Author Collection 
        /// </summary>
        private List<string> authorCollection;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public EventsViewModel()
        {
            this.events = new ObservableCollection<Event>();
            this.nonWorkingDays = new ObservableCollection<DayOfWeek>();
            this.InitializeDataForBookings();
            this.BookingAppointments();
        }

        /// <summary>
        /// Gets or sets list of meeting
        /// </summary>
        public ObservableCollection<Event> Events
        {
            get
            {
                return this.events;
            }

            set
            {
                this.events = value;
                this.RaiseOnPropertyChanged("Events");
            }
        }

        /// <summary>
        /// Gets or sets list of meeting
        /// </summary>
        public ObservableCollection<DayOfWeek> NonWorkingDays
        {
            get
            {
                return this.nonWorkingDays;
            }

            set
            {
                this.nonWorkingDays = value;
                this.RaiseOnPropertyChanged("Events");
            }
        }

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        internal void BookingAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 10; additionalAppointmentIndex++)
                    {
                        Event meeting = new Event();
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 20), 0, 0);
                        meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)] + "\n \n " + this.authorCollection[randomTime.Next(5)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.IsAllDay = false;
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;

                        this.events.Add(meeting);
                    }
                }
                else
                {
                    Event meeting = new Event();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 20), 0, 0);
                    meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)] + "\n \n " + this.authorCollection[randomTime.Next(5)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.IsAllDay = false;
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;

                    this.events.Add(meeting);
                }
            }
        }

        /// <summary>
        /// Method for adding non working days
        /// </summary>
        private void AddNonWorkingDays()
        {
            nonWorkingDays = new ObservableCollection<DayOfWeek>();
            nonWorkingDays.Add(DayOfWeek.Sunday);
            nonWorkingDays.Add(DayOfWeek.Saturday);
        }

        /// <summary>
        /// Method for get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Client Meeting");
            this.currentDayMeetings.Add("HR Meeting");
            this.currentDayMeetings.Add("Training session on Vue");
            this.currentDayMeetings.Add("Board Meeting");
            this.currentDayMeetings.Add("Support Meeting with Managers");
            this.currentDayMeetings.Add("Sprint Planning with Team members");
            this.currentDayMeetings.Add("Training session on C#");
            this.currentDayMeetings.Add("Appraisal Meeting");
            this.currentDayMeetings.Add("Meeting with General Manager");


            this.authorCollection = new List<string>();
            this.authorCollection.Add("Mr. Jamison");
            this.authorCollection.Add("Ms. Casey");
            this.authorCollection.Add("Mr. Percorino");
            this.authorCollection.Add("Ms. Gawade");
            this.authorCollection.Add("Mr. Shilling");
            this.authorCollection.Add("Mr. Paul Anderson");

            this.colorCollection = new List<Color>();
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));

        }

        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
