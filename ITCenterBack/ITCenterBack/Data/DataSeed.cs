using ITCenterBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Data
{
    public static class DataSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 4,
                    Name = "Основы компьютерной графики",
                    Age = "10-15 лет",
                    Description = "В индустрии компьютерной графики множество направлений: пространственный дизайн, обработка фотографий, дизайн логотипов, " +
                    "разработка трехмерных моделей, анимации и прочее. Цель данного курса – подготовить юных слушателей к знакомству с миром компьютерной графики, " +
                    "дизайна, композиции. Основным инструментом на курсе является всемирно известный редактор графики Adobe Photoshop, " +
                    "а также некоторые другие инструменты для творчества. Все эти навыки пригодятся для дальнейшей работы с самыми известными " +
                    "и полезными программами на других направлениях – Illustrator, Blender, Figma. В процессе обучения, " +
                    "слушатели смогут раскрыть в себе творческий потенциал и интерес к изучению определенной сферы графического дизайна. " +
                    "Знания, полученные на курсе «Основы компьютерной графики» обязательно пригодятся и в смежных сферах – разработке сайтов, игр, " +
                    "видеомонтаже, робототехнике",
                    Requirements = "уверенные навыки использования компьютера",
                    Image = "/assets/for_new/img/courses/design/starter-graphics.svg",
                    CourseType = CourseType.Design
                },
                new Course
                {
                    Id = 5,
                    Name = "Мой компьютер - для начинающих",
                    Age = "8-11 лет",
                    Description = "В современном мире, без навыков использования компьютера справиться с повседневными задачами в учебе и работе очень сложно. " +
                    "Курс «Мой компьютер» является первой ступеней в процессе подготовки будущего IT-специалиста, а также пригодится абсолютно любому современному " +
                    "человеку. На занятиях слушатели учатся уверенно использовать свой компьютер в качестве универсального инструмента для решения задач, обслуживать " +
                    "и настраивать операционную систему, изучают основные пакеты офисных программ. В рамках курса затрагиваются такие темы, как основы обработки графики, " +
                    "информационной безопасности и алгоритмизации",
                    Requirements = "нет",
                    Image = "/assets/for_new/img/courses/pk/my-pc.svg",
                    CourseType = CourseType.Development
                },
                new Course
                {
                    Id = 6,
                    Name = "3D графика, анимация и рендеринг",
                    Age = "12-17 лет",
                    Description = "Мир трехмерной графики охватывает множество направлений - геймдизайн и разработка игр, архитектурная визуализация и рендеринг, " +
                    "анимация и визуальные эффекты, 3D - печать и . На направлении \"3D-графика\" студенты изучают один из самых известных и гибких редакторов - Blender. " +
                    "Редактор Blender - мощный инструмент для создания трехмерных моделей, обладающий огромным сообществом фанатов и профессионалов, а также наличием " +
                    "большого количества модулей и плагинов, которые позволяют решить абсолютно любую задачу - от симуляции трехмерной виртуальной одежды, до просчетов " +
                    "физики жидкостей! Навыки, полученные при прохождении курса, расширяют возможности юных дизайнеров в сфере графического дизайна, а также открывают " +
                    "двери в такие направления, как разработка игр, архитектурную визуализацию и создание видеороликов с использованием 3D графики!",
                    Requirements = "предварительное прохождение курса \"Компьютерная графика\"",
                    Image = "/assets/for_new/img/courses/3d/graphics-3d.svg",
                    CourseType = CourseType.Design
                }
                );

            //Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Шпаков С А",
                    Description = "Робототехника LEGO EV3",
                    Image = "/images/Shpakov.jpg",
					Link = "https://vsu.by/universitet/ob-universitete/236-universitet/personalii/4140-shpakov-sergej-andreevich.html"
				}
                );

            //Admin
            var admin = new User
            {
                Id = 1, 
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };
			PasswordHasher<User> ph = new PasswordHasher<User>();
			admin.PasswordHash = ph.HashPassword(admin, "Admin_123");

			modelBuilder.Entity<User>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(new IdentityUserRole<long>
            {
                RoleId = 1,
                UserId = 1
            });

			//Schedule
			modelBuilder.Entity<Schedule>().HasData(
				new Schedule
				{
					Id = 1,
                    Description = "АКТУАЛЬНОЕ РАСПИСАНИЕ ВСЕГДА МОЖНО НАЙТИ\r\n НА СТЕНДЕ НАПРОТИВ ДЕКАНАТА (АУД. 316).",
                    Image = "/images/shedule.png"
				}
				);

			//Slider images
			modelBuilder.Entity<SliderImage>().HasData(
				new SliderImage
				{
					Id = 1,
					Image = "/assets/for_new/img/home-clubs/2.jpg"
				}
				);
			modelBuilder.Entity<SliderImage>().HasData(
				new SliderImage
				{
					Id = 2,
					Image = "/assets/for_new/img/home-clubs/3.jpg"
				}
				);
			modelBuilder.Entity<SliderImage>().HasData(
				new SliderImage
				{
					Id = 3,
					Image = "/assets/for_new/img/home-clubs/4.jpg"
				}
				);
			modelBuilder.Entity<SliderImage>().HasData(
				new SliderImage
				{
					Id = 4,
					Image = "/assets/for_new/img/home-clubs/5.jpg"
				}
				);

			//about us
			modelBuilder.Entity<AboutUs>().HasData(
				new AboutUs
				{
                    Id = 1,
                    Description = "IT-центр - открывает детям двери в мир IT, не забывая об их росте как личности и прививая им важные социальные ценности. " +
                    "Мы больше, чем просто компьютерные курсы для детей. Мы предоставляем не только обучение программированию или робототехнике, но и все возможности для роста," +
                    " общения и развития.\r\n" +
                    "IT-центр - стиль жизни и образ мышления, среда роста и творчества. Современный рынок цифровых продуктов - " +
                    "это уже не поле для деятельности специалистов-одиночек, это полигон борьбы глобальных проектов. Мы готовим специалистов, нацеленных на командную работу и общий успех!\r\n                                        ",
                    Url = "https://www.youtube.com/embed/KrreehNgcgA"
				}
				);

			//links
			modelBuilder.Entity<SocialLink>().HasData(
				new SocialLink
				{
                    Id = 1,
					Name = "ВКонтакте",
                    Url = "https://vk.com/mf_vsu"
				}
				);
			modelBuilder.Entity<SocialLink>().HasData(
				new SocialLink
				{   
                    Id = 2,
					Name = "Instagram",
					Url = "https://www.instagram.com/fmiit_vsu/"
				}
				);
			modelBuilder.Entity<SocialLink>().HasData(
				new SocialLink
				{
					Id = 3,
					Name = "Телеграм",
					Url = "https://t.me/fmiit_vsu"
				}
				);
			modelBuilder.Entity<SocialLink>().HasData(
				new SocialLink
				{
					Id = 4,
					Name = "Сайт факультета",
					Url = "https://fmiit.vsu.by/"
				}
				);

			//info
			modelBuilder.Entity<Info>().HasData(
				new Info
				{
					Id = 1,
					NameOfTheCenter = "IT-центр",
                    NameOfUniversity = "ВГУ имени П.М.Машерова",
                    AdressOfUniversity = "Республика Беларусь 210038, г. Витебск, Московский проспект 33",
                    SliderFirstText = "УЧРЕЖДЕНИЕ ОБРАЗОВАНИЯ \"ВГУ ИМЕНИ П.М.МАШЕРОВА\"",
                    SliderSecondText = "IT-центр",
					SliderThirdText = "\"Мир будущего\"",
                    HeaderLogo = "/assets/for_new/img/icons/logo.svg",
                    FooterLogo = "/images/gllg.png",
					PhoneNumber1 = "8 (0212) 37-58-36",
					PhoneNumber2 = "+375 (33) 317-95-02",
					Email = "fmiit@vsu.by"
                }
				);

            //Schools
            modelBuilder.Entity<School>().HasData(
                new School
                {
                    Id = 1,
                    Name = "Гимназия № 1 имени Ж.И.Алфёрова"
				}
                );
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 2,
					Name = "Гимназия № 2"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 3,
					Name = "Гимназия № 3 имени А.С.Пушкина"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 4,
					Name = "Гимназия № 4"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 5,
					Name = "Гимназия № 5 имени И.И.Людникова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 6,
					Name = "Гимназия № 7 имени П.Е.Кондратенко"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 7,
					Name = "Гимназия № 8"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 8,
					Name = "Гимназия № 9 имени А.П.Белобородова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 9,
					Name = "Средняя школа № 2 имени Ф.Т.Блохина"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 10,
					Name = "Средняя школа № 3 имени Л.Н.Белицкого"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 11,
					Name = "Средняя школа № 4"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 12,
					Name = "Средняя школа № 5 имени Г.И.Богомазова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 13,
					Name = "Средняя школа № 6 имени А.Е.Белохвостикова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 14,
					Name = "Средняя школа № 7"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 15,
					Name = "Средняя школа № 8 имени А.М.Испенкова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 16,
					Name = "Средняя школа № 9"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 17,
					Name = "Средняя школа № 10 имени А.К.Горовца"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 18,
					Name = "Средняя школа № 11"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 19,
					Name = "Средняя школа № 12 имени Л.Н.Филипенко"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 20,
					Name = "Средняя школа № 14"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 21,
					Name = "Средняя школа № 15 имени М.Я.Чуманихиной"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 22,
					Name = "Средняя школа № 16 имени М.И.Дружинина"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 23,
					Name = "Средняя школа № 17 имени И.Р.Бумагина"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 24,
					Name = "Средняя школа № 18 имени В.С.Сметанина"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 25,
					Name = "Средняя школа № 19"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 26,
					Name = "Средняя школа № 21 имени В.А.Демидова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 27,
					Name = "Средняя школа № 22"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 28,
					Name = "Средняя школа № 23 имени О.Р.Тувальского"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 29,
					Name = "Средняя школа № 24 имени М.Ф.Маскаева"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 30,
					Name = "Средняя школа № 25"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 31,
					Name = "Средняя школа № 27"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 32,
					Name = "Средняя школа № 28 имени Е.С.Зеньковой"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 33,
					Name = "Средняя школа № 29 имени В.В.Пименова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 34,
					Name = "Средняя школа № 30"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 35,
					Name = "Средняя школа № 31 имени В.З.Хоружей"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 36,
					Name = "Средняя школа № 33 имени И.Д.Черняховского"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 37,
					Name = "Средняя школа № 34"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 38,
					Name = "Средняя школа № 35"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 39,
					Name = "Средняя школа № 38"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 40,
					Name = "Средняя школа № 40 имени М.М.Громова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 41,
					Name = "Средняя школа № 41"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 42,
					Name = "Средняя школа № 42 имени Д.Ф.Райцева"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 43,
					Name = "Средняя школа № 43 имени М.Ф.Шмырёва"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 44,
					Name = "Средняя школа № 44"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 45,
					Name = "Средняя школа № 45 имени В.Ф.Маргелова"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 46,
					Name = "Средняя школа № 46 имени И.Х.Баграмяна"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 47,
					Name = "Средняя школа № 47 имени Е.Ф.Ивановского"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 48,
					Name = "Специальная  школа № 26"
				}
				);
			modelBuilder.Entity<School>().HasData(
				new School
				{
					Id = 49,
					Name = "Витебская специальная школа-интернат"
				}
				);

            //sections 
            modelBuilder.Entity<Section>().HasData(
                new Section
                {
                    Id = 1,
                    Name = "Математика",
					Description = "На занятиях по математике слушатели IT-академии занимаются\r\n\r\n " +
					"решением задач игрового, логического и занимательного характера с целью выявления и развития математических способностей и углубления интереса к математике, " +
					"а также повышения общего уровня математических знаний, умений и навыков.\r\n Кроме того в рамках курсов подробно разбираются задачи различных математических " +
					"олимпиад, турниров и конкурсов.\r\n Продемонстрировать полученные умения и навыки учащиеся могут приняв участие в следующих мероприятиях:\r\n" +
					"Международный математический Турнир городов (по г.Витебску)\r\n Республиканский турнир юных математиков\r\n Районные и областные этапы республиканской " +
					"олимпиады школьников по математике и многих других мероприятиях\r\n Слушатели, проявившие себя с наилучшей стороны, могут принять участие в работе " +
					"Республиканской летней научно-исследовательской школы “Бригантина”.\r\n Для учащихся 10-11 классов в рамках работы секции проводятся курсы подготовки к ЦТ.\r\n",
					Image = "/assets/for_new/img/courses/c/c.svg"
                }
                );
            modelBuilder.Entity<Section>().HasData(
                new Section
                {
                    Id = 2,
                    Name = "Информатика и программирование",
					Description = "В рамках секции информатики и программирования занятия проводятся по следующим направлениям:\r\n\r\n Scratch-программирование: " +
					"курс предназначен для самых юных слушателей TI-академии и направлен на изучение основ алгоритмизации и программирования на базе языка Scratch.\r\n" +
					"Java для начинающих: язык программирования Java является одним из наиболее популярных и распространенных в мире на текущий момент. " +
					"В рамках данного курса ученики познакомятся с его синтаксисом и изучат способы его применения для решения задач.\r\n" +
					"Web-программирование: курс посвящен изучению таких технологий как HTML/CSS/JS, которые применяются при разработке сайтов и клиентской частей интернет-приложений.\r\n" +
					" Компьютерная графика и web-дизайн: данный курс будет полезен всем, кто занимается художественным творчеством и желает использовать компьютер как инструмент в художественной деятельности.\r\n " +
					"Кроме того, учащиеся IT-академии имеют возможность проявить себя, принимая участие в различных мероприятиях и соревнованиях по информатике и программированию как республиканского так и международного уровня.\r\n",
					Image = "/assets/for_new/img/courses/c/c.svg"
                }
                );
            modelBuilder.Entity<Section>().HasData(
                new Section
                {
                    Id = 3,
                    Name = "Физика и робототехника",
					Description = "За время учебы на курсах «физика и робототехника» слушатели развивают умения и навыки работы с техническими устройствами на примере " +
					"образовательной робототехники на базе платформ Lego, Arduino и Festo Robotino.\r\n\r\n Платформа LEGO Mindstorms EV3 является наиболее популярной при " +
					"изучении робототехники. С помощью различных сочетаний программных блоков, моторов и датчиков можно заставить модели ходить, говорить, захватывать предметы, " +
					"думать, стрелять и выполнять любые действия, которые только можно придумать.\r\n Arduino – это небольшая плата с собственным процессором и памятью. " +
					"В Arduino можно загрузить программу, которая будет управлять различными устройствами по заданному алгоритму. Таким образом можно создать множество уникальных " +
					"и классных механизмов, сделанных своими руками и по собственной задумке.\r\n Помимо этого слушатели изучают теоретические основы робототехники. " +
					"Рассматриваются такие темы как механика и электричество. А также во время курсов ученики имеют возможность посетить планетарий университета, оснащенный " +
					"современными телескопами, и узнать больше о Солнечной системе и Вселенной.\r\n",
					Image = "/assets/for_new/img/courses/c/c.svg"
                }
                );
        }
	}
}
