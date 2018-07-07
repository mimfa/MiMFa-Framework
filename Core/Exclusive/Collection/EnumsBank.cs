using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiMFa_Framework.Exclusive.Collection
{
    #region Person
    public enum MiMFa_Sex
    {
        Null = -1,
        Male,
        Female
    }
    public enum MiMFa_Marital
    {
        Null = -1,
        Single,
        Married
    }
    public enum MiMFa_Accessibility
    {
        Null = -1,
        Guest,
        User,
        Operator,
        Administrator
    }
    #endregion

    #region Date & Time
    public enum MiMFa_GeneralAge
    {
        Modern,
        Classical,
        Historical
    }
    public enum MiMFa_DayOfWeek
    {
        Null = -1,
        Saturday = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6
    }
    public enum MiMFa_MonthName
    {
        Null = -1,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
    public enum MiMFa_PeriodType
    {
        Null = -1,
        Day,
        Week,
        Month,
        Year,
        Decade,
        Century,
        Millennium
    }
    public enum MiMFa_VacationType
    {
        Null = -1,
        Official,
        NonOfficial
    }
    public enum MiMFa_DayType
    {
        Null = -1,
        WorkDay,
        OfficialHoliday,
        NonOfficialHoliday,
        RestDay,
        LeaveDay,
        TestDay
    }
    public enum MiMFa_TimeZone
    {
        Null = -1
        , Acre
        , Afghanistan
        , AIXSpecificEquivalentOfCentralEuropean
        , AlaskaDaylight
        , AlaskaStandard
        , AmazonSummer_Brazil
        , AmazonBrazil
        , ArabiaStandard
        , Argentina
        , Armenia
        , ASEANCommon
        , AtlanticDaylight
        , AtlanticStandard
        , AustralianCentralDaylightSavings
        , AustralianCentralStandard
        , AustralianEasternDaylightSavings
        , AustralianEasternStandard
        , AustralianWesternDaylight
        , AustralianWesternStandard
        , Azerbaijan
        , AzoresStandard
        , BakerIsland
        , BangladeshDaylight_BangladeshDaylightSaving
        , BangladeshStandard
        , Bhutan
        , Bolivia
        , BougainvilleStandard
        , BrasiliaSummer
        , Brasilia
        , BritishIndianOcean
        , BritishSummer_BritishStandard
        , Brunei
        , CapeVerde
        , CentralAfrica
        , CentralDaylight_NorthAmerica
        , CentralEuropeanDaylight
        , CentralEuropeanSummer_CfHAEC
        , CentralEuropean
        , CentralIndonesia
        , CentralStandard_Australia
        , CentralStandard_NorthAmerica
        , CentralSummer_Australia
        , CentralWesternStandard_AustraliaUnofficial
        , ChamorroStandard
        , ChathamDaylight
        , ChathamStandard
        , ChileStandard
        , ChileSummer
        , ChinaStandard
        , China
        , Choibalsan
        , ChristmasIsland
        , Chuuk
        , ClippertonIslandStandard
        , CocosIslands
        , ColombiaSummer
        , Colombia
        , CookIsland
        , CoordinatedUniversal
        , CubaDaylight
        , CubaStandard
        , Davis
        , DumontDUrville
        , EastAfrica
        , EasterIslandStandardSummer
        , EasterIslandStandard
        , EasternCaribbean_DoesNotRecogniseDST
        , EasternDaylight_NorthAmerica
        , EasternEuropeanDaylight
        , EasternEuropeanSummer
        , EasternEuropean
        , EasternGreenlandSummer
        , EasternGreenland
        , EasternIndonesian
        , EasternStandard_Australia
        , EasternStandard_NorthAmerica
        , Ecuador
        , FalklandIslandsStandard
        , FalklandIslandsSummer
        , FalklandIslands
        , FernandoDeNoronha
        , Fiji
        , FrenchGuiana
        , FurtherEasternEuropean
        , Galapagos
        , GambierIsland
        , GambierIslands
        , GeorgiaStandard
        , GilbertIsland
        , GreenwichMean
        , GulfStandard
        , Guyana
        , HawaiiStandard
        , HawaiiAleutianDaylight
        , HawaiiAleutianStandard
        , HeardAndMcDonaldIslands
        , HeureAvancéeD_EuropeCentraleFrancisedNameForCEST
        , HongKong
        , IndianOcean
        , IndianStandard
        , IndianKerguelen
        , Indochina
        , InternationalBusinessStandard
        , IranDaylight
        , IranStandard
        , IrishStandard
        , Irkutsk
        , IsraelDaylight
        , IsraelStandard
        , JapanStandard
        , Kaliningrad
        , Kamchatka
        , Khovd
        , KoreaStandard
        , Kosrae
        , Krasnoyarsk
        , Kyrgyzstan
        , LineIslands
        , LordHoweStandard
        , LordHoweSummer
        , MacquarieIslandStation
        , Magadan
        , MalaysiaStandard
        , Malaysia
        , Maldives
        , MarquesasIslands
        , MarshallIslands
        , Mauritius
        , MawsonStation
        , MiddleEuropeanSummer_SameZoneAsCEST
        , MiddleEuropean_SameZoneAsCET
        , Moscow
        , MountainDaylight_NorthAmerica
        , MountainStandard_NorthAmerica
        , MyanmarStandard
        , Myanmar
        , Nepal
        , NewCaledonia
        , NewZealandDaylight
        , NewZealandStandard
        , NewfoundlandDaylight
        , NewfoundlandStandard
        , Newfoundland
        , Niue
        , Norfolk
        , Omsk
        , Oral
        , PacificDaylight_NorthAmerica
        , PacificStandard_NorthAmerica
        , PakistanStandard
        , PapuaNewGuinea
        , ParaguaySummer_SouthAmerica
        , Paraguay_SouthAmerica
        , Peru
        , PhilippineStandard
        , PhoenixIsland
        , PohnpeiStandard
        , RotheraResearchStation
        , Réunion
        , SaintPierreAndMiquelonDaylight
        , SaintPierreAndMiquelonStandard
        , SakhalinIsland
        , Samara
        , SamoaStandard
        , Seychelles
        , ShowaStation
        , SingaporeStandard
        , Singapore
        , SolomonIslands
        , SouthAfricanStandard
        , SouthGeorgiaAndTheSouthSandwichIslands
        , Srednekolymsk
        , SriLankaStandard
        , Suriname
        , Tahiti
        , Tajikistan
        , ThailandStandard
        , TimorLeste
        , Tokelau
        , Tonga
        , Turkmenistan
        , Tuvalu
        , Ulaanbaatar
        , UruguayStandard
        , UruguaySummer
        , Uzbekistan
        , Vanuatu
        , VenezuelanStandard
        , Vladivostok
        , Volgograd
        , VostokStation
        , WakeIsland
        , WestAfricaSummer
        , WestAfrica
        , WesternEuropeanDaylight
        , WesternEuropeanSummer
        , WesternEuropean
        , WesternIndonesian
        , WesternStandard
        , Yakutsk
        , Yekaterinburg
        , Zulu
    }
    #endregion

    #region Work & Education
    public enum MiMFa_ExamType
    {
        Null = -1,
        Intelligent = 0,
        Network = 1,
        Sheet = 2,
        Website = 3
    }
    public enum MiMFa_EducationalDegree
    {
        Null = -1,
        UnLiterate,
        LowLiteracy,
        Literacy,
        VocationalDiploma,
        Diploma,
        AssociateDegree,
        BSc,
        MSc,
        PhD,
        PostDoctoral
    }
    public enum MiMFa_Score
    {
        Null = -1,
        Positive,
        Negative,
        Both
    }
    public enum MiMFa_WorkLevel
    {
        Null = -1,
        HourlyWorker,
        ContractWorker,
        SimpleWorker,
        Foreman,
        HourlyEmployee,
        ContractEmployee,
        SimpleEmployee,
        SpecializedEmployee,
        DeputySection,
        HeadedSection,
        DeputyAreas,
        HeadedAreas,
        DeputyGeneral,
        Chief
    }
    public enum MiMFa_ShiftType
    {
        Null = -1,
        Fixed,
        Rotation
    }
    public enum MiMFa_LeaveType
    {
        Null = -1,
        Paid,
        Sick,
        UnPaid,
        Case,
        Parturition,
        Marriage
    }
    public enum MiMFa_PersonInsurance
    {
        Null = -1,
        UnInsured,
        HealthInsurance,
        PensionInsurance,
        PensionAndHealthInsurance
    }

    #endregion

    #region Math
    public enum MiMFa_Layout
    {
        Null = -1,
        Both,
        Horizental,
        Vertical
    }
    public enum MiMFa_WeightCompare
    {
        Null = -1,
        Low,
        More,
        Equals
    }
    public enum MiMFa_GrowSide
    {
        Null = -1,
        Decreasing,
        Increasing,
        Equals
    }
    public enum MiMFa_ImportantDegree
    {
        Null = -1,
        VeryLow,
        Low,
        Medium,
        High,
        VeryHigh,
    }
    public enum MiMFa_SettingStatus
    {
        Null = -1,
        Default,
        Equal,
        Special
    }
    public enum MiMFa_SelectFromRange
    {
        Null = -1,
        OrderBy,
        Random,
        Special
    }
    public enum MiMFa_StateType
    {
        Negative = -1,
        Middle = 0,
        Positive = 1
    }
    #endregion

    #region Dialog
    public enum MiMFa_MessageType
    {
        Null = -1,
        Text,
        Alert,
        Risk,
        Success,
        Error
    }
    #endregion

    #region Localization

    public enum MiMFa_Language
    {
        Null = -1,
        Abkhazian ,
        Acehnese ,
        Afar ,
        Afrikaans ,
        Akan ,
        Albanian ,
        Alemannic ,
        Amharic ,
        AngloSaxon ,
        Arabic ,
        Aragonese ,
        Aramaic ,
        Armenian ,
        Aromanian ,
        Assamese ,
        Asturian ,
        Avar ,
        Aymara ,
        Azerbaijani ,
        Bambara ,
        Banjar ,
        Banyumasan ,
        Bashkir ,
        Basque ,
        Bavarian ,
        Belarusian ,
        BelarusianTaraškievica ,
        Bengali ,
        Bihari ,
        BishnupriyaManipuri ,
        Bislama ,
        Bosnian ,
        Breton ,
        Buginese ,
        Bulgarian ,
        Burmese ,
        Buryat ,
        Cantonese ,
        Catalan ,
        Cebuano ,
        CentralBicolano ,
        Chamorro ,
        Chechen ,
        Cherokee ,
        Cheyenne ,
        Chichewa ,
        Chinese ,
        Choctaw ,
        Chuvash ,
        ClassicalChinese ,
        Cornish ,
        Corsican ,
        Cree ,
        CrimeanTatar ,
        Croatian ,
        Czech ,
        Danish ,
        Divehi ,
        Dutch ,
        DutchLowSaxon ,
        Dzongkha ,
        EgyptianArabic ,
        EmilianRomagnol ,
        English ,
        Erzya ,
        Esperanto ,
        Estonian ,
        Ewe ,
        Extremaduran ,
        Faroese ,
        Fijian ,
        FijiHindi ,
        Finnish ,
        FrancoProvençal ,
        French ,
        Friulian ,
        Fula ,
        Gagauz ,
        Galician ,
        Gan ,
        Georgian ,
        German ,
        Gilaki ,
        GoanKonkani ,
        Gothic ,
        Greek ,
        Greenlandic ,
        Guarani ,
        Gujarati ,
        Haitian ,
        Hakka ,
        Hausa ,
        Hawaiian ,
        Hebrew ,
        Herero ,
        HillMari ,
        Hindi ,
        HiriMotu ,
        Hungarian ,
        Icelandic ,
        Ido ,
        Igbo ,
        Ilokano ,
        Indonesian ,
        Interlingua ,
        Interlingue ,
        Inuktitut ,
        Inupiak ,
        Irish ,
        Italian ,
        Japanese ,
        Javanese ,
        KabardianCircassian ,
        Kabyle ,
        Kalmyk ,
        Kannada ,
        Kanuri ,
        Kapampangan ,
        KarachayBalkar ,
        Karakalpak ,
        Kashmiri ,
        Kashubian ,
        Kazakh ,
        Khmer ,
        Kikuyu ,
        Kinyarwanda ,
        Kirghiz ,
        Kirundi ,
        Komi ,
        KomiPermyak ,
        Kongo ,
        Korean ,
        Kuanyama ,
        Kurdish ,
        Ladino ,
        Lak ,
        Lao ,
        Latgalian ,
        Latin ,
        Latvian ,
        Lezgian ,
        Ligurian ,
        Limburgish ,
        Lingala ,
        Lithuanian ,
        Lojban ,
        Lombard ,
        LowerSorbian ,
        LowSaxon ,
        Luganda ,
        Luxembourgish ,
        Macedonian ,
        Maithili ,
        Malagasy ,
        Malay ,
        Malayalam ,
        Maltese ,
        Manx ,
        Maori ,
        Marathi ,
        Marshallese ,
        Mazandarani ,
        MeadowMari ,
        Minangkabau ,
        MinDong ,
        Mingrelian ,
        MinNan ,
        Mirandese ,
        Moksha ,
        Moldovan ,
        Mongolian ,
        Muscogee ,
        Nahuatl ,
        Nauruan ,
        Navajo ,
        Ndonga ,
        Neapolitan ,
        Nepali ,
        Newar ,
        Norfolk ,
        Norman ,
        NorthernLuri ,
        NorthernSami ,
        NorthernSotho ,
        NorthFrisian ,
        NorwegianBokmål ,
        NorwegianNynorsk ,
        Novial ,
        Occitan ,
        OldChurchSlavonic ,
        Oriya ,
        Oromo ,
        Ossetian ,
        PalatinateGerman ,
        Pali ,
        Pangasinan ,
        Papiamentu ,
        Pashto ,
        PennsylvaniaGerman ,
        Persian ,
        Picard ,
        Piedmontese ,
        Polish ,
        Pontic ,
        Portuguese ,
        Punjabi ,
        Quechua ,
        Ripuarian ,
        Romani ,
        Romanian ,
        Romansh ,
        Russian ,
        Rusyn ,
        Sakha ,
        Samoan ,
        Samogitian ,
        Sango ,
        Sanskrit ,
        Sardinian ,
        SaterlandFrisian ,
        Scots ,
        ScottishGaelic ,
        Serbian ,
        SerboCroatian ,
        Sesotho ,
        Shona ,
        SichuanYi ,
        Sicilian ,
        Silesian ,
        SimpleEnglish ,
        Sindhi ,
        Sinhalese ,
        Slovak ,
        Slovenian ,
        Somali ,
        Sorani ,
        SouthAzerbaijani ,
        Spanish ,
        Sranan ,
        Sundanese ,
        Swahili ,
        Swati ,
        Swedish ,
        Tagalog ,
        Tahitian ,
        Tajik ,
        Tamil ,
        Tarantino ,
        Tatar ,
        Telugu ,
        Tetum ,
        Thai ,
        Tibetan ,
        Tigrinya ,
        TokPisin ,
        Tongan ,
        Tsonga ,
        Tswana ,
        Tumbuka ,
        Turkish ,
        Turkmen ,
        Tuvan ,
        Twi ,
        Udmurt ,
        Ukrainian ,
        UpperSorbian ,
        Urdu ,
        Uyghur ,
        Uzbek ,
        Venda ,
        Venetian ,
        Vepsian ,
        Vietnamese ,
        Volapük ,
        Võro ,
        Walloon ,
        WarayWaray ,
        Welsh ,
        WesternPunjabi ,
        WestFlemish ,
        WestFrisian ,
        Wolof ,
        Wu ,
        Xhosa ,
        Yiddish ,
        Yoruba ,
        ZamboangaChavacano ,
        Zazaki ,
        Zeelandic ,
        Zhuang ,
        Zulu
    }
    public enum MiMFa_Country
    {
        Null=-1
        ,Afghanistan  
        ,Albania  
        ,Algeria  
        ,AmericanSamoa  
        ,Andorra  
        ,Angola  
        ,Anguilla  
        ,AntiguaAndBarbuda  
        ,Argentina  
        ,Armenia  
        ,Aruba  
        ,Australia  
        ,Austria  
        ,Azerbaijan  
        ,Bahamas  
        ,Bahrain  
        ,Bangladesh  
        ,Barbados  
        ,Belarus  
        ,Belgium  
        ,Belize  
        ,Benin  
        ,Bermuda  
        ,Bhutan  
        ,Bolivia  
        ,Bonaire  
        ,BosniaHerzegovina  
        ,Botswana  
        ,BouvetIsland  
        ,Brazil  
        ,Brunei  
        ,Bulgaria  
        ,BurkinaFaso  
        ,Burundi  
        ,Cambodia  
        ,Cameroon  
        ,Canada  
        ,CapeVerde  
        ,CaymanIslands  
        ,CentralAfricanRepublic  
        ,Chad  
        ,Chile  
        ,China  
        ,ChristmasIsland  
        ,CocosKeelingIslands  
        ,Colombia  
        ,Comoros  
        ,Congo_DemocraticRepublicOfTheZaire  
        ,Congo_RepublicOf  
        ,CookIslands  
        ,CostaRica  
        ,Croatia  
        ,Cuba  
        ,Curacao  
        ,Cyprus  
        ,CzechRepublic  
        ,Denmark  
        ,Djibouti  
        ,Dominica  
        ,DominicanRepublic  
        ,Ecuador  
        ,Egypt  
        ,ElSalvador  
        ,EquatorialGuinea  
        ,Eritrea  
        ,Estonia  
        ,Ethiopia  
        ,FalklandIslands  
        ,FaroeIslands  
        ,Fiji  
        ,Finland  
        ,France  
        ,FrenchGuiana  
        ,Gabon  
        ,Gambia  
        ,Georgia  
        ,Germany  
        ,Ghana  
        ,Gibraltar  
        ,Greece  
        ,Greenland  
        ,Grenada  
        ,GuadeloupeFrench  
        ,GuamUSA  
        ,Guatemala  
        ,Guinea  
        ,GuineaBissau  
        ,Guyana  
        ,Haiti  
        ,HolySee  
        ,Honduras  
        ,HongKong  
        ,Hungary  
        ,Iceland  
        ,India  
        ,Indonesia  
        ,Iran  
        ,Iraq  
        ,Ireland  
        ,Israel  
        ,Italy  
        ,IvoryCoastCoteDIvoire  
        ,Jamaica  
        ,Japan  
        ,Jordan  
        ,Kazakhstan  
        ,Kenya  
        ,Kiribati  
        ,Kosovo  
        ,Kuwait  
        ,Kyrgyzstan  
        ,Laos  
        ,Latvia  
        ,Lebanon  
        ,Lesotho  
        ,Liberia  
        ,Libya  
        ,Liechtenstein  
        ,Lithuania  
        ,Luxembourg  
        ,Macau  
        ,Macedonia  
        ,Madagascar  
        ,Malawi  
        ,Malaysia  
        ,Maldives  
        ,Mali  
        ,Malta  
        ,MarshallIslands  
        ,MartiniqueFrench  
        ,Mauritania  
        ,Mauritius  
        ,Mayotte  
        ,Mexico  
        ,Micronesia  
        ,Moldova  
        ,Monaco  
        ,Mongolia  
        ,Montenegro  
        ,Montserrat  
        ,Morocco  
        ,Mozambique  
        ,Myanmar  
        ,Namibia  
        ,Nauru  
        ,Nepal  
        ,Netherlands  
        ,NetherlandsAntilles  
        ,NewCaledoniaFrench  
        ,NewZealand  
        ,Nicaragua  
        ,Niger  
        ,Nigeria  
        ,Niue  
        ,NorfolkIsland  
        ,NorthKorea  
        ,NorthernMarianaIslands  
        ,Norway  
        ,Oman  
        ,Pakistan  
        ,Palau  
        ,Panama  
        ,PapuaNewGuinea  
        ,Paraguay  
        ,Peru  
        ,Philippines  
        ,PitcairnIsland  
        ,Poland  
        ,PolynesiaFrench  
        ,Portugal  
        ,PuertoRico  
        ,Qatar  
        ,Reunion  
        ,Romania  
        ,Russia  
        ,Rwanda  
        ,SaintHelena  
        ,SaintKittsAndNevis  
        ,SaintLucia  
        ,SaintPierreAndMiquelon  
        ,SaintVincentAndGrenadines  
        ,Samoa  
        ,SanMarino  
        ,SaoTomeAndPrincipe  
        ,SaudiArabia  
        ,Senegal  
        ,Serbia  
        ,Seychelles  
        ,SierraLeone  
        ,Singapore  
        ,SintMaarten  
        ,Slovakia  
        ,Slovenia  
        ,SolomonIslands  
        ,Somalia  
        ,SouthAfrica  
        ,SouthGeorgiaAndSouthSandwichIslands  
        ,SouthKorea  
        ,SouthSudan  
        ,Spain  
        ,SriLanka  
        ,Sudan  
        ,Suriname  
        ,SvalbardAndJanMayenIslands  
        ,Swaziland  
        ,Sweden  
        ,Switzerland  
        ,Syria  
        ,Taiwan  
        ,Tajikistan  
        ,Tanzania  
        ,Thailand  
        ,TimorLesteEastTimor  
        ,Togo  
        ,Tokelau  
        ,Tonga  
        ,TrinidadAndTobago  
        ,Tunisia  
        ,Turkey  
        ,Turkmenistan  
        ,TurksAndCaicosIslands  
        ,Tuvalu  
        ,Uganda  
        ,Ukraine  
        ,UnitedArabEmirates  
        ,UnitedKingdom  
        ,UnitedStates  
        ,Uruguay  
        ,Uzbekistan  
        ,Vanuatu  
        ,Venezuela  
        ,Vietnam  
        ,VirginIslands  
        ,WallisAndFutunaIslands  
        ,Yemen  
        ,Zambia  
        ,Zimbabwe  
        ,xk  
    }
   
    #endregion

    #region Position
    public enum MiMFa_SidePosition
    {
        Null = -1,
        Left,
        Top,
        Right,
        Bottom
    }
    public enum MiMFa_Position
    {
        Null = -1,
        Left,
        Top,
        Center,
        Right,
        Bottom
    }
    public enum MiMFa_Route
    {
        Null = -1,
        Start,
        Middle,
        End
    }

    #endregion

    #region Extension
    public enum MiMFa_ImageExtension
    {
        Null= -1,
        AllImageFile,
        jpg,
        jpeg,
        png, 
        gif,
        bmp,
        tif
    }
    public enum MiMFa_ExecuteType
    {
        Null = -1,
        ExecuteScalar,
        ExecuteNonQuery,
        ExecuteReader,
        ExecuteScalarAsync,
        ExecuteNonQueryAsync,
        ExecuteReaderAsync
    }
    public enum MiMFa_QuestionType
    {
        Null = -1,
        Descriptive,
        Supplementary,
        MultipleChoice
    }
    #endregion

    #region Programming
    public enum MiMFa_ProgrammingAccessibility
    {
        Public = 0, Internal = 1, Protected = 2, Private = 3
    }
    public enum MiMFa_ThreadingMethod
    {
        Null = -1,Default = 0, SingleThread = 1, MultiThread = 2, SingleTask = 3, MultiTask = 4, BackgroundWorker = 5
    }
    public enum MiMFa_Boolean
    {
        Null = -1,
        False = 0,
        True = 1
    }
    public enum MiMFa_Similarity
    {
        Null = -1,
        This = 0,
        Duplicate = 1,
        Same = 2,
        Like = 3,
        Congruent = 4
    }
    public enum MiMFa_Usage
    {
        Null = -1,
        Get = 0,
        Set = 1
    }
    public enum MiMFa_LinkJob
    {
        Null = -1,
        InternalPage = 0,
        ExternalPage = 1,
        Download = 2
    }
    public enum MiMFa_TableValuePositionType
    {
        Null = -1,
        NextRowCell = 0,
        NextColumnCell = 1,
        NextSubCell = 2,
    }
    #endregion
}
