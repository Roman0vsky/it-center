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
                    Image = "/images/Shpakov.jpg"
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
		}
    }
}
