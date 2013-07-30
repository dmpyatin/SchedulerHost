namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillDatabase : DbMigration
    {
        public override void Up()
        {
            String query = String.Empty;

            #region Add faculties

            query = @"
                SET IDENTITY_INSERT [dbo].[Faculties] ON
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (1, N'Медицинский факультет', N'Медецинский')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (2, N'Экономический факультет', N'Экономический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (3, N'Строительный факультет', N'Строительный')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (4, N'Факультет политических и социальных наук', N'Политических и социальных наук')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (5, N'Факультет прибалтийско-финской филологии и культуры', N'Прибалтийско-финской филологии и культуры')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (6, N'Агротехнический факультет', N'Агротехнический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (7, N'Физико-технический факультет', N'Физико-технический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (8, N'Эколого-биологический факультет', N'Эколого-биологический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (9, N'Исторический факультет', N'Исторический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (10, N'Лесоинженерный факультет', N'Лесоинженерный')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (11, N'Математический факультет', N'Математический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (12, N'Кафедра туризма', N'Туризма')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (13, N'Юридический факультет', N'Юридический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (14, N'Горно-геологический факультет', N'Горно-геологический')
                INSERT [dbo].[Faculties] ([Id], [Name], [ShortName]) VALUES (15, N'Филологический факультет', N'Филологический')
                SET IDENTITY_INSERT [dbo].[Faculties] OFF";

            Sql(query);

            #endregion

            #region Add departments

            query = @"
                SET IDENTITY_INSERT [dbo].[Departments] ON
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (1, N'Кафедра нормальной анатомии и гистологии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (2, N'Кафедра топографической и патологической анатомии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (3, N'Кафедра физиологии человека и животных', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (4, N'Кафедра иностранных языков медико-биологических специальностей', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (5, N'Кафедра пропедевтики внутренних болезней', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (6, N'Кафедра фармакологии и ОЭФ', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (7, N'Кафедра факультетской терапии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (8, N'Кафедра госпитальной хирургии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (9, N'Кафедра психиатрии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (10, N'Кафедра неврологии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (11, N'Кафедра акушерства и гинекологии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (12, N'Кафедра общей и факультетской хирургии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (13, N'Кафедра госпитальной терапии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (14, N'Кафедра педиатрии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (15, N'Кафедра критической и респираторной медицины', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (16, N'Кафедра детской хирургии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (17, N'Кафедра лучевой диагностики и лучевой терапии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (18, N'Кафедра семейной медицины (общей врачебной практики)', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (19, N'Кафедра инфекционных болезней с курсом эпидемиологии', NULL, 1)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (20, N'Кафедра бухгалтерского учета, анализа хозяйственной деятельности и аудита', NULL, 2)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (21, N'Кафедра теоретической экономики и государственного и муниципального управления', NULL, 2)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (22, N'Кафедра экономической теории и финансов', NULL, 2)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (23, N'Кафедра менеджмента', NULL, 2)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (24, N'Кафедра экономики и управления производством', NULL, 2)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (25, N'Кафедра архитектуры, строительных конструкций и геотехники', NULL, 3)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (26, N'Кафедра организации строительного производства', NULL, 3)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (27, N'Кафедра начертательной геометрии и инженерной графики', NULL, 3)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (28, N'Кафедра механики', NULL, 3)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (29, N'Кафедра водоснабжения, гидравлики и водоотведения', NULL, 3)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (30, N'Кафедра систем автоматизированного проектирования', NULL, 3)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (31, N'Кафедра политологии', NULL, 4)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (32, N'Кафедра социологии', NULL, 4)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (33, N'Кафедра социальной работы', NULL, 4)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (34, N'Кафедра международных отношений', NULL, 4)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (35, N'Кафедра иностранных языков факультета политических и социальных наук', NULL, 4)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (36, N'Кафедра финского языка и литературы', NULL, 5)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (37, N'Кафедра карельского и вепсского языков', NULL, 5)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (38, N'Кафедра агрономии, землеустройства и кадастров', NULL, 6)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (39, N'Кафедра зоотехнии, товароведения и экспертизы продовольственных товаров', NULL, 6)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (40, N'Кафедра механизации сельскохозяйственного производства', NULL, 6)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (41, N'Кафедра общей физики', NULL, 7)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (42, N'Кафедра физики твердого тела', NULL, 7)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (43, N'Кафедра информационно-измерительных систем и физической электроники', NULL, 7)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (44, N'Кафедра электроники и электроэнергетики', NULL, 7)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (45, N'Кафедра энергообеспечения предприятий и энергосбережения', NULL, 7)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (46, N'Кафедра русского языка', NULL, 15)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (47, N'Кафедра русской литературы и журналистики', NULL, 15)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (48, N'Кафедра германской филологии', NULL, 15)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (49, N'Кафедра классической филологии', NULL, 15)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (50, N'Кафедра кафедра скандинавских языков', NULL, 15)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (51, N'Кафедра общей химии', NULL, 8)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (52, N'Кафедра ботаники и физиологии растений', NULL, 8)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (53, N'Кафедра зоологии и экологии', NULL, 8)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (54, N'Кафедра молекулярной биологии, биологической и органической химии', NULL, 8)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (55, N'Кафедра геологии и геофизики', NULL, 14)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (56, N'Кафедра горного дела', NULL, 14)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (57, N'Кафедра всеобщей истории', NULL, 9)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (58, N'Кафедра истории дореволюционной России', NULL, 9)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (59, N'Кафедра отечественной истории (послереволюционный период)', NULL, 9)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (60, N'Кафедра истории стран Северной Европы', NULL, 9)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (61, N'Кафедра архивоведения и специальных исторических дисциплин', NULL, 9)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (62, N'Кафедра тяговых машин', NULL, 10)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (63, N'Кафедра технологии и оборудования лесного комплекса', NULL, 10)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (64, N'Кафедра промышленного транспорта и геодезии', NULL, 10)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (65, N'Кафедра лесного хозяйства', NULL, 10)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (66, N'Кафедра технологии металлов и ремонта', NULL, 10)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (67, N'Кафедра целлюлозно-бумажных и деревообрабатывающих производств', NULL, 10)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (68, N'Кафедра теории вероятностей и анализа данных', NULL, 11)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (69, N'Кафедра информатики и математического обеспечения', N'ИМО', 11)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (70, N'Кафедра математического анализа', NULL, 11)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (71, N'Кафедра прикладной математики и кибернетики', N'ПМиК', 11)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (72, N'Кафедра математического моделирования систем управления', NULL, 11)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (73, N'Кафедра геометрии и топологии', NULL, 11)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (74, N'Кафедра теории, истории государства и права', NULL, 13)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (75, N'Кафедра международного и конституционного права', NULL, 13)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (76, N'Кафедра гражданско-правовых дисциплин', NULL, 13)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (77, N'Кафедра уголовно-правовых дисциплин', NULL, 13)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (78, N'Кафедра иностранных языков гуманитарных факультетов', NULL, NULL)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (79, N'Кафедра иностранных языков технических факультетов', NULL, NULL)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (80, N'Кафедра культурологии', NULL, NULL)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (81, N'Курс Безопасность жизнедеятельности', NULL, NULL)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (82, N'Кафедра педагогики и психологии', NULL, NULL)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (83, N'Кафедра физического воспитания и спорта', NULL, NULL)
                INSERT [dbo].[Departments] ([Id], [Name], [ShortName], [Faculty_Id]) VALUES (84, N'Кафедра философии', NULL, NULL)
                SET IDENTITY_INSERT [dbo].[Departments] OFF";
            Sql(query);
            #endregion

            #region Add specialities

            query = @"
                SET IDENTITY_INSERT [dbo].[Specialities] ON
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (1, N'Информационные системы и технологии', N'ИСиТ', N'230201.65', 69)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (2, N'Информационные системы и технологии', N'ИСиТ', N'230400.62', 69)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (3, N'Информационные системы и технологии', N'ИСиТ', N'230400.68', 69)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (4, N'Бизнес-информатика', N'БИ', N'080500.62', 71)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (5, N'Бизнес-информатика', N'БИ', N'080500.68', 71)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (6, N'Математика', NULL, N'010100.62', 70)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (7, N'Математика', NULL, N'010100.68', 70)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (8, N'Математика', NULL, N'010101.65', 70)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (9, N'Прикладная математика и информатика', N'ПМИ', N'010400.62', 71)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (10, N'Прикладная математика и информатика', N'ПМИ', N'010400.68', 71)
                INSERT [dbo].[Specialities] ([Id], [Name], [ShortName], [Code], [Department_Id]) VALUES (11, N'Прикладная математика и информатика', N'ПМИ', N'010501.65', 71)
                SET IDENTITY_INSERT [dbo].[Specialities] OFF";

            Sql(query);

            #endregion

            #region Add courses

            query = @"
                SET IDENTITY_INSERT [dbo].[Courses] ON
                INSERT [dbo].[Courses] ([Id], [Name]) VALUES (1, N'Первый курс')
                INSERT [dbo].[Courses] ([Id], [Name]) VALUES (2, N'Второй курс')
                INSERT [dbo].[Courses] ([Id], [Name]) VALUES (3, N'Третий курс')
                INSERT [dbo].[Courses] ([Id], [Name]) VALUES (4, N'Четвертый курс')
                INSERT [dbo].[Courses] ([Id], [Name]) VALUES (5, N'Пятый курс')
                INSERT [dbo].[Courses] ([Id], [Name]) VALUES (6, N'Шестой курс')
                SET IDENTITY_INSERT [dbo].[Courses] OFF";
            Sql(query);
            #endregion

            #region Add groups

            query = @"
                SET IDENTITY_INSERT [dbo].[Groups] ON
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (1, 1, N'22101', 8)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (2, 1, N'22103', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (3, 1, N'22104', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (4, 1, N'22105', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (5, 1, N'22106', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (6, 1, N'22108', 5)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (7, 2, N'22201', 8)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (8, 2, N'22203', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (9, 2, N'22204', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (10, 2, N'22205', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (11, 2, N'22206', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (12, 2, N'22208', 5)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (13, 3, N'22301', 8)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (14, 3, N'22303', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (15, 3, N'22304', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (16, 3, N'22305', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (17, 3, N'22306', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (18, 3, N'22308', 5)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (19, 4, N'22401', 8)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (20, 4, N'22403', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (21, 4, N'22404', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (22, 4, N'22405', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (23, 4, N'22406', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (24, 4, N'22408', 5)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (25, 5, N'22501', 8)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (26, 5, N'22503', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (27, 5, N'22504', 11)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (28, 5, N'22505', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (29, 5, N'22506', 3)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (30, 5, N'22507', 5)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (31, 5, N'22509', 5)
                INSERT [dbo].[Groups] ([Id], [Course_Id], [Code], [Speciality_Id]) VALUES (32, 5, N'22510', 8)
                SET IDENTITY_INSERT [dbo].[Groups] OFF";

            Sql(query);

            #endregion

            #region Add ranks

            query = @"
                SET IDENTITY_INSERT [dbo].[Ranks] ON
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (1, N'Заведующий кафедрой', 1)
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (2, N'И.о. зав. кафедрой', 2)
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (3, N'Профессор', 3)
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (4, N'Доцент', 4)
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (5, N'Старший преподаватель', 5)
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (6, N'Преподаватель', 6)
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (7, N'Методист кафедры', 7)
                INSERT [dbo].[Ranks] ([Id], [Name], [Position]) VALUES (8, N'Инженер', 8)
                SET IDENTITY_INSERT [dbo].[Ranks] OFF";

            Sql(query);

            #endregion

            #region Add lecturers

            query = @"
                SET IDENTITY_INSERT [dbo].[Lecturers] ON
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (1,	N'Воронин',		N'Анатолий',	N'Викторович',		N'voronin@psu.karelia.ru ', 71, 1)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (2,	N'Щеголева',	N'Людмила',		N'Владимировна',	N'schegoleva@psu.karelia.ru ', 71, 2)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (3,	N'Заика',		N'Юрий',		N'Васильевич',		N'zaika@krc.karelia.ru ', 71, 3)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (4,	N'Кузнецов',	N'Владимир',	N'Алексеевич',		N'kuznetcv@mail.ru ', 71, 3)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (5,	N'Морозов',		N'Евсей',		N'Викторович',		N'emorozov@karelia.ru ', 71, 3)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (6,	N'Воронов',		N'Роман',		N'Владимирович',	N'rvoronov@karelia.ru ', 71, 4)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (7,	N'Лазарев',		N'Алексей',		N'Викторович',		N'lazarev_av@sampo.ru ', 71, 4)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (8,	N'Насадкина',	N'Ольга',		N'Юрьевна',			N'onasad@psu.karelia.ru ', 71, 4)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (9,	N'Перепечко',	N'Сергей',		N'Николаевич',		N'persn@newmail.ru ', 71, 4)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (10,	N'Пешкова',		N'Ирина',		N'Валерьевна',		N'iaminova@karelia.ru ', 71, 4)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (11,	N'Шабаев',		N'Антон',		N'Игоревич',		N'ashabaev@karelia.ru ', 71, 4)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (12,	N'Жуков',		N'Артем',		N'Владимирович',	N'zhukov@karelia.ru ', 71, 5)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (13,	N'Кириленко',	N'Александр',	N'Николаевич',		N'kiritigr@rambler.ru ', 71, 5)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (14,	N'Косицын',		N'Дмитрий',		N'Петрович',		N'kositsyn@psu.karelia.ru ', 71, 5)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (15,	N'Сошкин',		N'Роман',		N'Владимирович',	N'soshkin@mail.ru ', 71, 5)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (16,	N'Суровцева',	N'Татьяна',		N'Генадьевна',		N'tsurovceva@psu.karelia.ru ', 71, 5)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (17,	N'Сысун',		N'Александр',	N'Валерьевич',		N'sysun@petrsu.ru ', 71, 5)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (18,	N'Попов',		N'Алексей',		N'Львович',			N'alex5431@mail.ru ', 71, 5)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (19,	N'Андреева',	N'Юлия',		N'Александровна',	N'julana2008@yandex.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (20,	N'Апанасик',	N'Анастасия',	N'Михайловна',		N'anastasiyamih@mail.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (21,	N'Богданов',	N'Андрей',		N'Викторович',		NULL, 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (22,	N'Богданова',	N'Маргарита',	N'Владимировна',	N'bogdanov@karelia.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (23,	N'Власов',		N'Денис',		N'Петрович',		N'dpetrovich@onego.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (24,	N'Воронова',	N'Анна',		N'Михайловна',		N'voronova_am@petrsu.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (25,	N'Воропаев',	N'Антон',		N'Николаевич',		N'antonvoropaev@mail.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (26,	N'Гнеушева',	N'Наталья',		N'Владимировна',	N'natgn@goon.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (27,	N'Горинов',		N'Николай',		N'Александрович',	N'gorinov@karelia.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (28,	N'Горичева',	N'Руслана',		N'Сергеевна',		NULL, 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (29,	N'Гусев',		N'Олег',		N'Валерьевич',		N'http://gusev.eleset.ru', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (30,	N'Ивашко',		N'Евгений',		N'Евгеньевич',		NULL, 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (31,	N'Караваев',	N'Артем',		N'Михайлович',		N'http://karavaev.flowproblem.ru', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (32,	N'Лукашенко',	N'Олег',		N'Викторович',		NULL, 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (33,	N'Могилев',		N'Максим',		N'Викторович',		N'mcsymco@gmail.com ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (34,	N'Пустовит',	N'Татьяна',		N'Михайловна',		N'nola@psu.karelia.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (35,	N'Савинов',		N'Григорий',	N'Александрович',	N'mail@gyrr.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (36,	N'Смолий',		N'Юлия',		N'Андреевна',		N'Julia.Sidorova@metsopartners.com ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (37,	N'Соколов',		N'Владислав',	N'Евгеньевич',		N'svl@karelia.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (38,	N'Фомина',		N'Елена',		N'Анатольевна',		N'foelan@petrsu.ru ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (39,	N'Хентов',		N'Сергей',		N'Владимирович',	N'sergey.khentov@gmail.com ', 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (40,	N'Шлей',		N'Михаил',		N'Дмитриевич',		NULL, 71, 6)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (41,	N'Панченко',	N'Татьяна',		N'Борисовна',		N'pmik@petrsu.ru ', 71, 7)
                INSERT [dbo].[Lecturers] ([Id], [Lastname], [Firstname], [Middlename],  [Contacts], [Department_Id], [Rank_Id]) VALUES (42,	N'Прохоров',	N'Максим',		N'Андреевич',		NULL, 71, 8)
                SET IDENTITY_INSERT [dbo].[Lecturers] OFF";

            Sql(query);

            #endregion

            #region Add tutorials

            query = @"
                SET IDENTITY_INSERT [dbo].[Tutorials] ON
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (1, N'Дискретная математика', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (2, N'Доп. разделы инф. и прогр.', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (3, N'Комп. Практикум', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (4, N'Практикум по программированию', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (5, N'Программирование', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (6, N'Теор. основы информатики', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (7, N'Дифф. уравнения', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (8, N'Комбинаторные алгоритмы', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (9, N'ОО анализ и программирование', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (10, N'Теория алгоритмов', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (11, N'Методы оптимизации', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (12, N'Оптимизация и мат. методы принятия решений', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (13, N'Прикладные методы оптимизации', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (14, N'С/к Проекты', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (15, N'С/к Аудит управления ИКТ компании', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (16, N'С/к Технологии построения Интернета', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (17, N'Теория вероятностей и МС', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (18, N'Проектирование ИС', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (19, N'Эконометрика', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (20, N'Эффект. прогр. в Oracle', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (21, N'Корпоративные ИС', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (22, N'Исследование операций', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (23, N'Компьютерный практикум', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (24, N'Логистика', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (25, N'Орг. обеспечение. инф. безопасности', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (26, N'С/к Совр. технологии высокопроизв. вычислений', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (27, N'С/к Комб. алгоритмы. эксп. сложности', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (28, N'С/к Основы потоков в сетях', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (29, N'Теория управления', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (30, N'Управление производством', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (31, N'С/к основы финансовой математики', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (32, N'С/к структуры данных комб. алг.', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (33, N'Случайные процессы', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (34, N'Спецсеминар', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (35, N'Теория принятия решений', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (36, N'Управление ЖЦ ИС', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (37, N'Управление инф. рисками', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (38, N'С/к Дополнительные главы комбинаторики', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (39, N'С/к Современные системы управления', NULL)
                INSERT [dbo].[Tutorials] ([Id], [Name], [ShortName]) VALUES (40, N'Управление производством', NULL)
                SET IDENTITY_INSERT [dbo].[Tutorials] OFF";
            Sql(query);
            #endregion

            #region Add buildings

            query = @"
                SET IDENTITY_INSERT [dbo].[Buildings] ON
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (1, N'Главный корпус', N'пр. Ленина 33', N'ГК', NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (2, N'Учебный корпус №1', N'ул. Анохина 20', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (3, N'Учебный корпус №2', N'наб. Гюллинга 17', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (4, N'Учебный корпус №3', N'пр. Александра Невского 8', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (5, N'Учебный корпус №4', N'пр. Александра Невского 48', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (6, N'Учебно-лабораторный корпус №5', N'ул. Университетская 10', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (7, N'Учебно-лабораторный корпус №6', N'ул. Университетская 10а', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (8, N'Учебный корпус №7', N'наб. Варкауса 3', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (9, N'Учебный корпус №8', N'ул. Ломоносова 65', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (10, N'Учебный корпус №9', N'пр. Ленина 31', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (11, N'Теоретический корпус', N'ул. Красноармейская 31', N'ТК', NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (12, N'Морфологический корпус', N'ул. Фрунзе 31', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (13, N'Виварий', N'ул. Красноармейская 31Б', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (14, N'Общежитие №1', N'ул. Ломоносова 63', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (15, N'Общежитие №3', N'ул. Красноармейская 31А', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (16, N'Общежитие №4', N'ул. Белорусская 15', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (17, N'Общежитие №5', N'пр. Ленина 11Б', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (18, N'Общежитие №6', N'ул. Белорусская 17', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (19, N'Общежитие №7', N'ул. Фрунзе 7А', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (20, N'Общежитие №8', N'ул. Суорявская 5', NULL, NULL)
                INSERT [dbo].[Buildings] ([Id], [Name], [Address], [ShortName], [Info]) VALUES (21, N'Гараж и лабораторный ангар ФТФ', N'ул. Калевалы 15А', NULL, NULL)
                SET IDENTITY_INSERT [dbo].[Buildings] OFF";
            Sql(query);

            #endregion

            #region Add auditoriums
            query = @"
                SET IDENTITY_INSERT [dbo].[Auditoriums] ON
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (1, N'1', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (2, N'2', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (3, N'3', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (4, N'4', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (5, N'5', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (6, N'6', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (7, N'7', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (8, N'8', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (9, N'9', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (10, N'10', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (11, N'11', NULL, 12, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (12, N'12', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (13, N'13', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (14, N'14', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (15, N'15', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (16, N'16', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (17, N'17', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (18, N'18', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (19, N'19', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (20, N'20', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (21, N'21', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (22, N'22', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (23, N'23', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (24, N'24', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (25, N'25', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (26, N'26', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (27, N'27', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (28, N'28', NULL, 30, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (29, N'29', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (30, N'30', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (31, N'31', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (32, N'32', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (33, N'33', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (34, N'34', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (35, N'35', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (36, N'36', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (37, N'37', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (38, N'38', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (39, N'39', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (40, N'40', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (41, N'41', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (42, N'42', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (43, N'43', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (44, N'44', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (45, N'45', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (46, N'46', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (47, N'47', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (48, N'48', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (49, N'49', NULL, 60, NULL, 1)
                INSERT [dbo].[Auditoriums] ([Id], [Number], [Name], [Capacity], [Info], [Building_Id]) VALUES (50, N'50', NULL, 100, NULL, 1)
                SET IDENTITY_INSERT [dbo].[Auditoriums] OFF";

            Sql(query);
            #endregion

            #region Add times

            query = @"
                SET IDENTITY_INSERT [dbo].[Times] ON
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (1, '8:00', '9:35')
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (2, '9:45', '11:20')
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (3, '11:30', '13:05')
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (4, '13:30', '15:05')
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (5, '15:15', '16:50')
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (6, '17:00', '18:35')
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (7, '18:45', '20:20')
                INSERT [dbo].[Times] ([Id], [Start], [End]) VALUES (8, '20:30', '22:05')
                SET IDENTITY_INSERT [dbo].[Times] OFF";

            Sql(query);

            #endregion

            #region Add week types

            query = @"
                SET IDENTITY_INSERT [dbo].[TutorialTypes] ON
                INSERT [dbo].[TutorialTypes] ([Id], [Name]) VALUES (1, N'Лекция')
                INSERT [dbo].[TutorialTypes] ([Id], [Name]) VALUES (2, N'Практическое занятие')
                INSERT [dbo].[TutorialTypes] ([Id], [Name]) VALUES (3, N'Лабораторная работа')
                SET IDENTITY_INSERT [dbo].[TutorialTypes] OFF";
            Sql(query);
            #endregion
        }
        
        public override void Down()
        {
            Sql("Delete from Auditoriums");
            Sql("Delete from Buildings");
            Sql("Delete from Courses");
            Sql("Delete from Departments");
            Sql("Delete from Faculties");
            Sql("Delete from Ranks");
            Sql("Delete from Groups");
            Sql("Delete from Lecturers");
            Sql("Delete from Specialities");
            Sql("Delete from Times");
            Sql("Delete from Tutorials");
            Sql("Delete from TutorialTypes");
            Sql("Delete from WeekTypes");
        }
    }
}
