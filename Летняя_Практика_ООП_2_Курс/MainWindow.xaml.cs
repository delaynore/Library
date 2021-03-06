using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;

namespace Летняя_Практика_ООП_2_Курс
{
    public partial class MainWindow : Window
    {
        EntryWindow entryWindow;
        Reader reader;
        public MainWindow()
        {
            InitializeComponent();
            entryWindow = new EntryWindow(this);
            Hide();
            ShowEntryWindow();
        }

        public void ShowEntryWindow()
        {
            entryWindow.Show();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            entryWindow = new EntryWindow(this);
            entryWindow.Show();
        }

        public void EntryCloses(Reader reader)
        {
            this.reader = reader;
            Identity.Header = $"{reader.Name} : {reader.ReaderID + 800000}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (LibraryDB db = new LibraryDB())
            {
                //var keys = db.KeyWords.ToList();
                //Book book1 = new Book
                //{
                //    Author = "Дж.Р.Р.Толкин",
                //    Genre = "Фэнтези",
                //    Interpreter = "М.Каменкович",
                //    Name = "Властелин Колец",
                //    numberPages = 1097,
                //    publishingHouse = "АСТ",
                //    readingRoomNumber = 1,
                //    yearPublishing = 2017,
                //    Annotation = "Джон Рональд Руэл Толкин (3.01.1892 - 2.09.1973) - писатель, поэт, филолог, профессор Оксфордского университета, родоначальник современной фэнтези.\n" +
                //    "В 1937 году был написан Хоббит, а в середине 1950-х годов увидели свет три книги Властелина колец, повествующие о Средиземье - мире, населенном представителями \n" +
                //    "волшебных рас со сложной культурой, историей и мифологией. \n" +
                //    "Существует свыше десятка переводов трилогии на русский язык.\n" +
                //    "В данное издание вошел перевод Н.Эстель.",
                //    KeyWords = new List<KeyWord>() { keys[1], keys[3], keys[5], keys[6], keys[8], keys[10], keys[11], keys[12], keys[13] }
                //};

                //Book book2 = new Book
                //{
                //    Author = "А.Сапковский",
                //    Genre = "Фэнтези",
                //    Interpreter = "Е.П.Вайсброт",
                //    Name = "Ведьмак",
                //    numberPages = 1340,
                //    publishingHouse = "АСТ",
                //    readingRoomNumber = 1,
                //    yearPublishing = 2020,
                //    Annotation = "Одна из лучших фэнтези-саг за всю историю существования жанра. Оригинальное, масштабное эпическое произведение, одновременно и свободное от влияния извне, \n" +
                //    "и связанное с классической мифологической, легендарной и сказовой традицией. Шедевр не только писательского мастерства Анджея Сапковского, \n" +
                //    "но и переводческого искусства Евгения Павловича Вайсброта. Сага о Геральте - в одном томе. Бесценный подарок и для поклонника прекрасной фантастики, \n" +
                //    "и для ценителя просто хорошей литературы. Перед читателем буквально оживает необычный, прекрасный и жестокий мир литературной легенды, в котором обитают эльфы и гномы, \n" +
                //    "оборотни, вампиры и низушки-хоббиты, драконы и монстры, - но прежде всего ЛЮДИ.\n" +
                //    "Очень близкие нам,понятные и человечные люди - такие как мастер меча ведьмак Геральт,\n" +
                //    "его друг,беспутный менестрель Лютик,его возлюбленная,прекрасная чародейка Йеннифэр,и приемная дочь - безрассудно отважная юная Цири…",
                //    KeyWords = new List<KeyWord>() { keys[2], keys[3], keys[5], keys[9], keys[10], keys[11], keys[12], keys[13], keys[14] }
                //};

                //Book book3 = new Book
                //{
                //    Author = "Дж.К.Роулинг",
                //    Genre = "Фэнтези",
                //    Interpreter = "Махаон",
                //    Name = "Гарри Поттер",
                //    numberPages = 2170,
                //    publishingHouse = "Махаон",
                //    readingRoomNumber = 1,
                //    yearPublishing = 2017,
                //    Annotation = "В книге  Дж. К. Роулинг «Гарри Поттер» описываются удивительные приключения мальчика-сироты, который в возрасте одиннадцати лет узнал, \n" +
                //    "что неразрывно связан с тайным волшебным миром. Он отправляется на обучение  в школу чародейства Хогвартс, где постигает азы волшебства и заводит верных друзей. \n" +
                //    "Также Гарри узнает, что в этом волшебном мире живет жестокий и злой колдун, погубивший его родителей. Юному волшебнику предстоит встреча с опасным противником, \n" +
                //    "который решил во что бы то ни стало уничтожить и его самого.",
                //    KeyWords = new List<KeyWord>() { keys[1], keys[2], keys[4], keys[5], keys[7], keys[11], keys[14] }

                //};

                //Book book4 = new Book
                //{
                //    Author = "Д.Стикли",
                //    Genre = "Фэнтези",
                //    Interpreter = "",
                //    Name = "Вампиры",
                //    numberPages = 416,
                //    publishingHouse = "АСТ",
                //    readingRoomNumber = 3,
                //    yearPublishing = 2022,
                //    Annotation = "Охота на вампиров – занятие рискованное, ведь они живучие, умные и опасные монстры, убить которых очень непросто. " +
                //    "Потому им не занимаются исключительно ради денег. Кто-то делает это ради удовольствия, а кто-то из чувства долга. " +
                //    "И никто не выполняет подобную работу лучше Джека Ворона и его команды. Они странствуют по пыльным дорогам на юге Америки, " +
                //    "их презирают и боятся местные жители. Охотники знают, что Бог существует, только целей его не понимают. " +
                //    "И на последнем задании делают страшную ошибку, фатально недооценив противника. Практически весь отряд Джека погибает. " +
                //    "Теперь выжившим придется выработать новую стратегию, ведь они понимают, что столкнулись с чем-то куда страшнее обычных вампиров. " +
                //    "А еще им нужно найти новых охотников, вот только какой безумец захочет добровольно пойти на верную смерть?",
                //    KeyWords = new List<KeyWord>() { keys[2], keys[9], keys[12] }
                //};

                //Book book5 = new Book
                //{
                //    Author = "Ф.Хокинс",
                //    Genre = "Фэнтези",
                //    Interpreter = "А.Маркелова",
                //    Name = "Ведьма",
                //    numberPages = 382,
                //    publishingHouse = "Альпина.Дети",
                //    readingRoomNumber = 3,
                //    yearPublishing = 2022,
                //    Annotation = "XVII век. Англия. Смутное время заговоров и интриг, когда страна охвачена войной, а по дорогам рыскают охотники на ведьм." +
                //    " Рыжеволосая Иви не хочет даже слышать о магии. Она считает, что у нее нет никакого дара, и отчаянно завидует младшей сестре, любимице матери. " +
                //    "Когда охотники жестоко убивают их мать, Иви вынуждена присматривать за сестрой. Но в ее душе, терзаемой ревностью и гневом, нет места для любви. " +
                //    "Она оставляет сестру в мрачном ковене ведьм, а сама отправляется на поиски убийц. Она еще не знает, что сестра попадет в руки охотников " +
                //    "и в день страшного суда окажется на помосте... И тогда Иви придется узнать, кто она такая и на что способна.",
                //    KeyWords = new List<KeyWord>() { keys[2], keys[3], keys[11], keys[12] }
                //};

                //Book book6 = new Book
                //{
                //    Author = "О.Рой",
                //    Genre = "Фэнтези",
                //    Interpreter = "",
                //    Name = "Сердце Кая",
                //    numberPages = 368,
                //    publishingHouse = "РИПОЛ классик",
                //    readingRoomNumber = 4,
                //    yearPublishing = 2022,
                //    Annotation = "Любимые герои детства - Кай и Герда - возвращаются на стра- ницах напряжённого и непредсказуемого, магического и " +
                //    "приключенческого фэнтезийного романа Олега Роя Сердце Кая. Им вновь предстоит защитить свой мир и спасти друг друга от холодной смерти.",
                //    KeyWords = new List<KeyWord>() { keys[6], keys[7], keys[8] }
                //};

                //Book book7 = new Book
                //{
                //    Author = "Э.Лор",
                //    Genre = "Фэнтези",
                //    Interpreter = "И.Эрхарт",
                //    Name = "Город злодеев",
                //    numberPages = 384,
                //    publishingHouse = "Эксмо",
                //    readingRoomNumber = 4,
                //    yearPublishing = 2020,
                //    Annotation = "Только представьте — мрачный город, осаждённый коррупцией и охотой за деньгами, утраченная магия фей и волшебников, " +
                //    "трагедия, унёсшая жизни людей, тайна, требующая расследования… И всё это с героями знакомых с детства мультфильмов!" +
                //    "Урсула — школьница с татуировкой осьминога.Малефисента — дочь бизнесмена с вороном на плече.Безумный Шляпник — преступник.Таких историй Disney вы точно ещё не знали!",
                //    KeyWords = new List<KeyWord>() { keys[3], keys[4], keys[7], keys[8] }
                //};

                //Book book8 = new Book
                //{
                //    Author = "В.И.Евдокимов",
                //    Genre = "Боевик",
                //    Interpreter = "",
                //    Name = "Забытый берег",
                //    numberPages = 287,
                //    publishingHouse = "Центрполиграф",
                //    readingRoomNumber = 5,
                //    yearPublishing = 2021,
                //    Annotation = "Вячеслав Петрович Аксёнов, респектабельный москвич, успешный учёный, благополучный семьянин, внезапно получает «привет» из прошлого. " +
                //    "Четверть века назад, летом 1992 года, во времена суматошные и пропитанные запахом авантюризма, он вместе с ещё тремя бывшими однокурсниками получает " +
                //    "неожиданное наследство от институтского профессора: бумаги, указывающие местонахождение клада, зарытого в послереволюционные годы богатым волжским купцом. " +
                //    "Трое, Аксёнов и два его товарища, сговариваются втайне от четвёртого отправиться на поиски клада. Спустя 25 лет жив лишь Аксёнов, " +
                //    "уже забывший обо всех обстоятельствах той поездки, не задумывавшийся о том, почему именно их четвёрку выбрал профессор Богданов, и даже не предполагавший, " +
                //    "что вновь окажется на Волге, что за всё придётся отвечать.",
                //    KeyWords = new List<KeyWord>() { keys[8], keys[12], keys[16] }
                //};

                //Book book9 = new Book
                //{
                //    Author = "К.Дж.Сэнсом",
                //    Genre = "Боевик",
                //    Interpreter = "Ю.Соколов",
                //    Name = "Каменное Сердце",
                //    numberPages = 800,
                //    publishingHouse = "Азбука",
                //    readingRoomNumber = 5,
                //    yearPublishing = 2022,
                //    Annotation = "Лето 1545 года. Франция стягивает армаду своих кораблей к берегам Альбиона. Англия в опасности, и король Генрих VIII, " +
                //    "несмотря на кризис, охвативший страну, тратит последние денежные запасы на то, чтобы противостоять врагу. " +
                //    "Мэтью Шардлейк со своим верным помощником Джеком Бараком по поручению королевы Екатерины Парр отправляется в Портсмут, " +
                //    "самый уязвимый из городов, расположенных в непосредственной близости от корабельных пушек французов. Поручение у Шардлейка непростое: " +
                //    "следует разузнать все о некоем молодом человеке, воспитаннике королевского двора, и о том, почему его бывший учитель," +
                //    " посетивший поместье приемной семьи воспитанника, неожиданно покончил с собой..",
                //    KeyWords = new List<KeyWord>() { keys[1], keys[5], keys[6], keys[14], keys[20] }
                //};

                //Book book10 = new Book
                //{
                //    Author = "Грин Э.",
                //    Genre = "Романтика",
                //    Interpreter = "Комцян М. А.",
                //    Name = "Сны и желания",
                //    numberPages = 158,
                //    publishingHouse = "Центрполиграф",
                //    readingRoomNumber = 24,
                //    yearPublishing = 2011,
                //    Annotation = "Леонщас Парнассис впервые ступил на землю своих предков с одним желанием — отомстить человеку, ставшему причиной изгнания его семьи. " +
                //    "Случайно встретив на вечеринке дочь своего врага, Лео решает сделать ее своей любовницей и таким образом покрыть позором имя ненавистного ему рода. " +
                //    "Однако неожиданно пробудившееся нежное чувство к невинной девушке может помешать Лео осуществить план...",
                //    KeyWords = new List<KeyWord>() { keys[5], keys[9], keys[15], keys[17] }
                //};

                //Book book11 = new Book
                //{
                //    Author = "Мэтер Энн",
                //    Genre = "Романтика",
                //    Interpreter = "Ежова Г.",
                //    Name = "Мы увидимся вновь",
                //    numberPages = 158,
                //    publishingHouse = "Центрполиграф",
                //    readingRoomNumber = 24,
                //    yearPublishing = 2011,
                //    Annotation = "Изабел бросилась в объятия красивого бразильца как в омут с головой." +
                //    " И хотя Алессандро вскоре вернулся к себе на родину, она не смогла забыть его. " +
                //    "Спустя годы Изабел едет в Бразилию, чтобы взять интервью у знаменитой писательницы. " +
                //    "Она и не подозревает, что эта сеньора — родственница Алессандро...",
                //    KeyWords = new List<KeyWord>() { keys[5], keys[16], keys[7] }
                //};

                //Book book12 = new Book
                //{
                //    Author = "Доналд Р.",
                //    Genre = "Романтика",
                //    Interpreter = "",
                //    Name = "Любовники поневоле",
                //    numberPages = 154,
                //    publishingHouse = "Центрполиграф",
                //    readingRoomNumber = 24,
                //    yearPublishing = 2010,
                //    Annotation = "Кейн Джерард не на шутку встревожен — у его кузена Брента очередной роман! " +
                //    "Но на этот раз он увлекся не обычной красоткой, а хищницей, охотящейся на богатых мужчин. " +
                //    "К тому же у нее довольно темное прошлое." +
                //    " Чтобы спасти любвеобильного Брента от разорения, Кейн решает сам вмешаться в ситуацию.",
                //    KeyWords = new List<KeyWord>() { keys[5], keys[16] }
                //};

                //Book book13 = new Book
                //{
                //    Author = "Лукас Дж.",
                //    Genre = "Романтика",
                //    Interpreter = "Румянцева А.В.",
                //    Name = "Соблазнение невинной",
                //    numberPages = 255,
                //    publishingHouse = "Центрполиграф",
                //    readingRoomNumber = 24,
                //    yearPublishing = 2010,
                //    Annotation = "После десяти лет супружеской жизни со старым графом Лия Виллани осталась вдовой... " +
                //    "и девственницей. Ей уже ничего не нужно от жизни, она лишь мечтает разбить парк в центре Нью-Йорка. " +
                //    "Но прекрасный незнакомец предлагает ей любые деньги за этот участок земли, а заодно себя в качестве " +
                //    "любовника...",
                //    KeyWords = new List<KeyWord>() { keys[5], keys[12], keys[16], keys[19] }
                //};

                //Book book14 = new Book
                //{
                //    Author = "Джеймс М.",
                //    Genre = "Романтика",
                //    Interpreter = "Ежова Г.",
                //    Name = "Маленькое чудо",
                //    numberPages = 151,
                //    publishingHouse = "Центрполиграф",
                //    readingRoomNumber = 24,
                //    yearPublishing = 2011,
                //    Annotation = "Анна и Джерри любят друг друга, но их брак лишен главного — детей. " +
                //    "Не выдержав нравственных мучений, Анна уходит из дома." +
                //    " Но Джерри не из тех, кто сдается...",
                //    KeyWords = new List<KeyWord>() { keys[5], keys[16], keys[19] }
                //};

                //var books2 = new[]
                //{
                //    new Book
                //    {
                //        Author = "А. Бурков",
                //        Genre = "Наука и техника",
                //        Interpreter = "",
                //        Name = "Инженерия машинного обучения",
                //        numberPages = 306,
                //        publishingHouse = "ДМК",
                //        readingRoomNumber = 1,
                //        yearPublishing = 2022,
                //        Annotation = "Книга представляет собой подробный обзор передовых практик и " +
                //        "паттернов проектирования в области прикладного машинного обучения." +
                //        " В отличие от многих учебников, уделяется внимание инженерным аспектам МО." +
                //        " Рассматриваются сбор, хранение и предобработка данных, конструирование признаков," +
                //        " а также тестирование и отладка моделей, развертывание и вывод из эксплуатации, " +
                //        "сопровождение на этапе выполнения и в процессе эксплуатации. Главы книги можно изучать в любом порядке." +
                //        "Издание будет полезно тем, кто собирается использовать машинное обучение в крупномасштабных проектах" +
                //        ". Предполагается, что читатель знаком с основами МО и способен построить модель" +
                //        " при наличии подходящим образом отформатированного набора данных.",
                //        KeyWords = new List<KeyWord>() { keys[21], keys[22], keys[23] }
                //    },
                //    new Book
                //    {
                //        Author = "Р. Гримм",
                //        Genre = "Наука и техника",
                //        Interpreter = "",
                //        Name = "Параллельное программирование на современном С++",
                //        numberPages = 616,
                //        publishingHouse = "ДМК",
                //        readingRoomNumber = 1,
                //        yearPublishing = 2021,
                //        Annotation = "Книга во всех подробностях освещает параллельное программирование" +
                //        " на современном С++. Особое внимание уделено опасностям и трудностям параллельного" +
                //        " программирования (например, гонке данных и мертвой блокировке) и способам борьбы " +
                //        "с ними. Приводятся многочисленные примеры кода, позволяющие читателю легко закрепить" +
                //        " теорию на практических примерах." +
                //        "Издание адресовано читателям, которые хотят освоить параллельное программирование" +
                //        " на одном из наиболее распространенных языков.",
                //        KeyWords = new List<KeyWord>() { keys[21], keys[22] }
                //    },
                //    new Book
                //    {
                //        Author = "А.В. Федякин",
                //        Genre = "Наука и техника",
                //        Interpreter = "",
                //        Name = "История транспорта России: курс лекций: учебное пособие",
                //        numberPages = 440,
                //        publishingHouse = "Проспект",
                //        readingRoomNumber = 1,
                //        yearPublishing = 2022,
                //        Annotation = "В учебном пособии рассматривается ход и характер становления и" +
                //        " развития основных видов отечественного транспорта общего пользования " +
                //        "(железнодорожного, автомобильного, речного (внутреннего водного), морского" +
                //        ", воздушного, космического, трубопроводного, городского и пригородного пассажирского)," +
                //        " соответствующих путей и средств сообщения, техники, инфраструктуры и т. д. " +
                //        "Особое внимание уделяется теоретико-методологическим основаниям изучения истории транспорта России," +
                //        " а также вопросам формирования и трансформации отечественной системы государственного управления транспортным комплексом." +
                //        "Для студентов транспортных вузов, специалистов в области истории транспорта России" +
                //        ", государственной транспортной политики и управления транспортным комплексом, " +
                //        "а также всех, кто интересуется данной проблематикой в ее теоретическом и прикладном измерениях.",
                //        KeyWords = new List<KeyWord>() { keys[22], keys[23], keys[21] }
                //    },
                //    new Book
                //    {
                //        Author = "В.Леонов",
                //        Genre = "Наука и техника",
                //        Interpreter = "",
                //        Name = "Excel, Word. Лучший самоучитель для всех возрастов и поколений",
                //        numberPages = 240,
                //        publishingHouse = "Эксмо",
                //        readingRoomNumber = 1,
                //        yearPublishing = 2022,
                //        Annotation = "Универсальное руководство по работе с ноутбуком и компьютером. " +
                //        "Самоучитель спокойно и обстоятельно научит всему самому необходимому: " +
                //        "работать с файлами и папками, читать книги, смотреть фильмы, писать и " +
                //        "звонить близким. Каждый урок снабжен множеством иллюстраций, таблиц и" +
                //        " других справочных материалов. Работать на ноутбуке гораздо проще, чем кажется. " +
                //        "Проверьте сами!",
                //        KeyWords = new List<KeyWord>() { keys[21], keys[22], keys[23] }
                //    },
                //    new Book
                //    {
                //        Author = "Д.Нейман",
                //        Genre = "Наука и техника",
                //        Interpreter = "",
                //        Name = "Вычислительная машина и мозг",
                //        numberPages = 192,
                //        publishingHouse = "АСТ",
                //        readingRoomNumber = 1,
                //        yearPublishing = 2022,
                //        Annotation = "Один из величайших ученых ХХ века и одиниз отцов-основателей" +
                //        " современных информационных технологий, американецвенгерского происхождения" +
                //        " Джон фон Нейман прожил недолго (1903 – 1957), но за этот короткий период " +
                //        "успел отметиться значительными достижениями в области информатики," +
                //        " разработать теорию игр,внести существенный вклад в квантовую механику, " +
                //        "логику и концепцию клеточных автоматов и даже принять участие в Манхэттенском " +
                //        "проекте по разработке ядерного оружия. Информационные технологии кардинально" +
                //        " изменили жизнь человека,затронув каждую ее сторону – от бизнеса инауки до" +
                //        " политики и искусства. Искусственный интеллект перестал быть фантастикой и " +
                //        "сделался реальностью. Иименно эта всесторонняя компьютеризация общества" +
                //        " поставила перед нами новый фундаментальный вопрос: какова разница между" +
                //        " интеллектом искусственным и интеллектом человеческим, и есть ли она вообще?" +
                //        " Джон фон Нейман, в своей поистине пророческой, выдержавшей испытание временем" +
                //        " и до сих пор регулярно переиздающейся книге, утверждает: такая разница минимальна." +
                //        " Несмотря на все различия в архитектуре и строительных блоках мозга и вычислительной" +
                //        " машины, искусственный интеллект, тем не менее, способен имитировать работу мозга.",
                //        KeyWords = new List<KeyWord>() { keys[21], keys[22], keys[23] }
                //    },
                //};

                //db.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14);
                //db.Books.AddRange(books2);
                //db.SaveChanges();
                var books = db.Books.ToList().Where(b => reader == null || !b.CurrentReaderId.HasValue == false && (reader.familiarizedBooks == null || !reader.familiarizedBooks.Contains(b))).ToList();
                ListBoxBooks.ItemsSource = books;
                Title = books.Count.ToString();
            }   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Button).Tag.ToString(),"Аннотация");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно желаете ознакомиться с данной книгой?", "take book", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (LibraryDB db = new LibraryDB())
                {
                    var book = db.Books.Find(int.Parse((sender as Button).Tag.ToString()));
                    book.CurrentReader = reader;
                    db.SaveChanges();
                    var books = db.Books.ToList().Where(b => !b.CurrentReaderId.HasValue);
                    ListBoxBooks.ItemsSource = books;

                    if(MessageBox.Show("Желаете посмотреть дополнительную литературу по данной книге?","Доп.литература",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        ListBoxBooks.ItemsSource = Recommendator.AdditionalBooks(int.Parse((sender as Button).Tag.ToString()));
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)// обновить список
        {
            using (LibraryDB db = new LibraryDB())
            {
                ListBoxBooks.ItemsSource = db.Books.ToList().Where(b => !b.CurrentReaderId.HasValue && !reader.familiarizedBooks.Contains(b));
            }
        }

        private void MenuItemCurrentBooks_Click(object sender, RoutedEventArgs e)
        {
            using (LibraryDB db = new LibraryDB())
            {
                ListBoxBooks.ItemsSource = reader.onHandsBooks;
            }
        }

        private void MenuItemReadBooks_Click(object sender, RoutedEventArgs e)
        {
            using (LibraryDB db = new LibraryDB())
            {
                ListBoxBooks.ItemsSource = reader.familiarizedBooks;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            ListBoxBooks.ItemsSource = Recommendator.AlternateBook(int.Parse((sender as Button).Tag.ToString()));
        }
    }
}
