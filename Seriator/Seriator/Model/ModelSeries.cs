using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seriator.Model
{
    class ModelSeries
    {
        private int seriesId;
        private int seriesSeason;
        private int seriesStatus;
        private int seriesCategory;
        private int seriesUser;
        private double seriesEpisodes;
        private double seriesEpisodePerSeason;
        private double seriesCurrentSeason;
        private double seriesCurrentEpisode;
        private double seriesDuration;
        private string seriesProgressSeason;
        private string seriesProgressEpisodes;
        private string seriesTitle;
        private string seriesCategoryTitle;
        private string seriesSynopsys;
        private DateTime seriesFinishDate;

        public int SeriesId
        {
            get
            {
                return seriesId;
            }

            set
            {
                seriesId = value;
            }
        }

        public int SeriesSeason
        {
            get
            {
                return seriesSeason;
            }

            set
            {
                seriesSeason = value;
            }
        }

        public int SeriesStatus
        {
            get
            {
                return seriesStatus;
            }

            set
            {
                seriesStatus = value;
            }
        }

        public int SeriesCategory
        {
            get
            {
                return seriesCategory;
            }

            set
            {
                seriesCategory = value;
            }
        }

        public int SeriesUser
        {
            get
            {
                return seriesUser;
            }

            set
            {
                seriesUser = value;
            }
        }

        public double SeriesEpisodes
        {
            get
            {
                return seriesEpisodes;
            }

            set
            {
                seriesEpisodes = value;
            }
        }

        public double SeriesEpisodePerSeason
        {
            get
            {
                return seriesEpisodePerSeason;
            }

            set
            {
                seriesEpisodePerSeason = value;
            }
        }

        public double SeriesCurrentSeason
        {
            get
            {
                return seriesCurrentSeason;
            }

            set
            {
                seriesCurrentSeason = value;
            }
        }

        public double SeriesCurrentEpisode
        {
            get
            {
                return seriesCurrentEpisode;
            }

            set
            {
                seriesCurrentEpisode = value;
            }
        }

        public double SeriesDuration
        {
            get
            {
                return seriesDuration;
            }

            set
            {
                seriesDuration = value;
            }
        }

        public string SeriesProgressSeason
        {
            get
            {
                return seriesProgressSeason;
            }

            set
            {
                seriesProgressSeason = value;
            }
        }

        public string SeriesProgressEpisodes
        {
            get
            {
                return seriesProgressEpisodes;
            }

            set
            {
                seriesProgressEpisodes = value;
            }
        }

        public string SeriesTitle
        {
            get
            {
                return seriesTitle;
            }

            set
            {
                seriesTitle = value;
            }
        }

        public string SeriesCategoryTitle
        {
            get
            {
                return seriesCategoryTitle;
            }

            set
            {
                seriesCategoryTitle = value;
            }
        }

        public string SeriesSynopsys
        {
            get
            {
                return seriesSynopsys;
            }

            set
            {
                seriesSynopsys = value;
            }
        }

        public DateTime SeriesFinishDate
        {
            get
            {
                return seriesFinishDate;
            }

            set
            {
                seriesFinishDate = value;
            }
        }
    }
}