using System;

namespace Exchange_Statistics_Monitor
{
    static class Sectors
    {
        public static string Oil
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "OilAndGas")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (OilAndGas)");
            }
        }
        public static string Electricity
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "Electricity")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (Electricity)");
            }
        }
        public static string Media
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "Media")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (Media)");
            }
        }
        public static string MetalMinning
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "MetalMinning")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (MetalMinning)");
            }
        }
        public static string Financial
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "Financial")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (Financial)");
            }
        }
        public static string Consumer
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "Consumer")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (Consumer)");
            }
        }
        public static string Chemicals
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "Chemicals")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (Chemicals)");
            }
        }
        public static string Transport
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "Transport")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (Transport)");
            }
        }
        public static string Uknown
        {
            get
            {
                foreach (string sector in sectors)
                {
                    if (sector == "not_specified")
                    {
                        return sector;
                    }
                }
                throw new NullReferenceException("No sector found! (Uknown)");
            }
        }
        public static int Count { get => count; }
        private static string[] sectors;
        private static string[] sectorsInfo;
        private static int count;

        public static void InitializeSectors()
        {
            //warning! not specified is replaced with not_specified (pay attention to underscore!)
            sectors = new string[] 
            { 
                "OilAndGas",
                "Electricity",
                "Media",
                "MetalMinning",
                "Financial",
                "Consumer",
                "Chemicals",
                "Transport",
                "not_specified" 
            };

            sectorsInfo =  new string[] 
            { 
                "Нефть и газ",
                "Энергетика",
                "IT технологии, связь и СМИ",
                "Добыча и переаботка руды и металлов",
                "Финансы и инвестиции",
                "Потребительский сектор",
                "Химическая промышленность и фармацевтика",
                "Логистика и транспорт",
                "Другое" 
            };

            if (sectors.Length != sectorsInfo.Length)
            {
                throw new ArgumentOutOfRangeException("non equal amount of sectors and sectors info");
            }
            count = sectors.Length;
        }

        public static string[] GetInfo()
        {
            return sectorsInfo;
        }

        public static string[] GetAll()
        {
            return sectors;
        }
    }
}
