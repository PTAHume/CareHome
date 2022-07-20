
using CareHome.Data;
using Microsoft.EntityFrameworkCore;


namespace CareHome.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new CareHomeContext(
                serviceProvider.GetRequiredService<DbContextOptions<CareHomeContext>>());

            if (context.Departments?.Any() == false)
            {
                context?.Departments?.AddRange(SeedDepartments());
                context?.SaveChanges();
            }

            if (context?.EthnicityGroups?.Any() == false)
            {
                context.EthnicityGroups.AddRange(SeedEthnicityGroups());
                context?.SaveChanges();
            }

            if (context?.GenderTypes?.Any() == false)
            {
                context.GenderTypes.AddRange(SeedGenderTypes());
                context?.SaveChanges();
            }
        }

        public static List<Departments> SeedDepartments()
        {
            return new List<Departments>()
            {
                new Departments
                {
                    Name = "Ancillary roles",
                    Description =
                        "These roles don’t involve direct care but are vital to the running of an organisation.",
                    JobTitles =
                        new List<JobTitles>()
                        {
                            new JobTitles
                            {
                                Title = "Activities worker",
                                Description =
                                    "You’ll organise social activities for people who need care and support, including trips out, entertainment and supporting people to take part.,",
                                DefaultSalary = 20000
                            },
                            new JobTitles
                            {
                                Title = "Care worker",
                                Description =
                                    "You’ll support people with all aspects of their day to day living, including social and physical activities, personal care, mobility and meal times.",
                                DefaultSalary = 24000
                            }
                        }
                },
                new Departments
                {
                    Name = "Regulated professional roles",
                    Description =
                        "These roles mean you have to be registered with a regulated body to practice. They require relevant qualifications which might include an undergraduate degree or diploma.",
                    JobTitles =
                        new List<JobTitles>()
                        {
                            new JobTitles
                            {
                                Title = "Personal assistant",
                                Description =
                                    "You’ll support an individual to live as independently as possible, usually in their own home or in the community.",
                                DefaultSalary = 30000,
                            },
                            new JobTitles
                            {
                                Title = "Rehabilitation worker",
                                Description =
                                    "You’ll support people to live independently, often following an illness or accident, and help them access support with housing, finance, social activities and life skills such as cooking or budgeting.",
                                DefaultSalary = 27000,
                            },
                            new JobTitles
                            {
                                Title = "Shared lives carer",
                                Description =
                                    "You’ll open up your home and family life to include someone who needs care and support. They might come and live with you all the time or be a daytime visitor for a few hours a week.",
                                DefaultSalary = 22000,
                            },
                            new JobTitles
                            {
                                Title = "Welfare rights officer",
                                Description =
                                    "You’ll advise people around matters relating to legislation such as housing benefits, disability living allowances, employment benefits and rent support.",
                                DefaultSalary = 29000,
                            },
                            new JobTitles
                            {
                                Title = "Advocacy worker",
                                Description =
                                    "You’ll support vulnerable people to have their voice heard and ensure that their best interests are taken into consideration when decisions are being made about their lives.",
                                DefaultSalary = 25000,
                            }
                        }
                },
                new Departments
                {
                    Name = "Other social care support roles",
                    Description = "General miscellaneous roles ",
                    JobTitles =
                        new List<JobTitles>()
                        {
                            new JobTitles
                            {
                                Title = "Cook or kitchen assistant",
                                Description =
                                    "You’ll prepare, cook and serve meals to people usually in a nursing or residential home, or in a day care centre.",
                                DefaultSalary = 19000,
                            },
                            new JobTitles
                            {
                                Title = "Housekeeper or domestic worker",
                                Description =
                                    "You’ll ensure that the environment in a residential home or sheltered housing is safe, tidy and clean.",
                                DefaultSalary = 18000,
                            },
                            new JobTitles
                            {
                                Title = "Driver or transport manager",
                                Description =
                                    "You’ll provide transport for people who need care and support, for example to and from a day centre or to hospital appointments.",
                                DefaultSalary = 33000,
                            },
                            new JobTitles
                            {
                                Title = "Maintenance",
                                Description =
                                    "You’ll carry out practical maintenance jobs, usually in a residential home or sheltered housing.",
                                DefaultSalary = 21500,
                            }
                        }
                },
                new Departments
                {
                    Name = "Management roles",
                    Description =
                        "These roles involve managerial responsibility where you could be responsible for managing a small team, or be the CEO of an organisation.",
                    JobTitles =
                        new List<JobTitles>()
                        {
                            new JobTitles
                            {
                                Title = "Team leader or supervisor",
                                Description =
                                    "You’ll lead or supervise a team of care workers to ensure they provide high quality care and support.",
                                DefaultSalary = 40000,
                            },
                            new JobTitles
                            {
                                Title = "Manager",
                                Description =
                                    "Depending on your level, you’ll be responsible for the day to day running of the organisation, ensuring it meets standards and managing budgets and contracts.",
                                DefaultSalary = 45000,
                            },
                            new JobTitles
                            {
                                Title = "Deputy manager or team manager",
                                Description =
                                    "You’ll specialise in one area of care such as dementia or end of life care and take responsibility for training staff and putting policies in place.",
                                DefaultSalary = 44000,
                            },
                            new JobTitles
                            {
                                Title = "Housing support officer",
                                Description =
                                    "You’ll provide housing related support and advice to ensure people keep their tenancy and live independently.",
                                DefaultSalary = 41000,
                            },
                            new JobTitles
                            {
                                Title = "Volunteer coordinator",
                                Description =
                                    "You’ll be responsible for finding, managing and coordinating volunteers across an organisation or location.",
                                DefaultSalary = 36000,
                            },
                            new JobTitles
                            {
                                Title = "Social care prescriber",
                                Description =
                                    "You’ll connect people with non-medical support in the community to improve their wellbeing and tackle social isolation.",
                                DefaultSalary = 38000,
                            }
                        }
                },
                new Departments
                {
                    Name = "Direct care roles",
                    Description = "These roles involve directly working with people who need care and support",
                    JobTitles =
                        new List<JobTitles>()
                        {
                            new JobTitles
                            {
                                Title = "Administration roles including finance, HR and marketing",
                                Description =
                                    "You’ll carry out administration tasks to support the organisation in finance, HR and marketing.",
                                DefaultSalary = 26000,
                            },
                            new JobTitles
                            {
                                Title = "Employment advisor",
                                Description =
                                    "You’ll support people who need care and support to find and maintain employment.",
                                DefaultSalary = 28700,
                            },
                            new JobTitles
                            {
                                Title = "Trainer or assessor",
                                Description =
                                    "You’ll design and deliver learning and development sessions to improve the knowledge and skills of staff.",
                                DefaultSalary = 25700,
                            },
                            new JobTitles
                            {
                                Title = "Social worker",
                                Description =
                                    "You’ll offer counselling and advocacy to individuals and families, and intervene where vulnerable people need safeguarding.",
                                DefaultSalary = 31500,
                            },
                            new JobTitles
                            {
                                Title = "Occupational therapist",
                                Description =
                                    "You’ll work with people with physical, mental or social disabilities to help do everyday activities such as with physical rehabilitation or equipment for daily living.",
                                DefaultSalary = 35800,
                            },
                            new JobTitles
                            {
                                Title = "Nurse (including nursing associate)",
                                Description =
                                    "You’ll perform clinical tasks to people in a nursing home or in the community.",
                                DefaultSalary = 27700,
                            },
                            new JobTitles
                            {
                                Title = "Complementary therapist",
                                Description =
                                    "You’ll provide complementary therapies such as reflexology, massage and aromatherapy to people who may be experiencing emotional distress, pain or psychological issues.",
                                DefaultSalary = 32700,
                            }
                        }
                }
            };
        }

        public static IList<EthnicityGroups> SeedEthnicityGroups()
        {
            return new List<EthnicityGroups>()
            {
                new EthnicityGroups
                {
                    GroupName = "Asian or Asian British",
                    EthnicityClasses =
                        new List<EthnicityTypes>()
                        {
                            new EthnicityTypes { EthnicityName = "Indian" },
                            new EthnicityTypes { EthnicityName = "Pakistani" },
                            new EthnicityTypes { EthnicityName = "Bangladeshi" },
                            new EthnicityTypes { EthnicityName = "Chinese" },
                            new EthnicityTypes { EthnicityName = "Any other Asian background" }
                        }
                },
                new EthnicityGroups
                {
                    GroupName = "Black, Black British, Caribbean or African",
                    EthnicityClasses =
                        new List<EthnicityTypes>()
                        {
                            new EthnicityTypes { EthnicityName = "Caribbean" },
                            new EthnicityTypes { EthnicityName = "African" },
                            new EthnicityTypes
                            {
                                EthnicityName = "Any other Black, Black British, or Caribbean background"
                            }
                        }
                },
                new EthnicityGroups
                {
                    GroupName = "Mixed or multiple ethnic groups",
                    EthnicityClasses =
                        new List<EthnicityTypes>()
                        {
                            new EthnicityTypes { EthnicityName = "White and Black Caribbean" },
                            new EthnicityTypes { EthnicityName = "White and Black African" },
                            new EthnicityTypes { EthnicityName = "White and Asian" },
                            new EthnicityTypes { EthnicityName = "Any other Mixed or multiple ethnic background" }
                        }
                },
                new EthnicityGroups
                {
                    GroupName = "White",
                    EthnicityClasses =
                        new List<EthnicityTypes>()
                        {
                            new EthnicityTypes { EthnicityName = "English, Welsh, Scottish, Northern Irish or British" },
                            new EthnicityTypes { EthnicityName = "Irish" },
                            new EthnicityTypes { EthnicityName = "Gypsy or Irish Traveller" },
                            new EthnicityTypes { EthnicityName = "Roma" },
                            new EthnicityTypes { EthnicityName = "Any other White background" }
                        }
                },
                new EthnicityGroups
                {
                    GroupName = "Other ethnic group",
                    EthnicityClasses =
                        new List<EthnicityTypes>()
                        {
                            new EthnicityTypes { EthnicityName = "Arab" },
                            new EthnicityTypes { EthnicityName = "Any other ethnic group" }
                        }
                }
            };
        }

        public static IList<GenderTypes> SeedGenderTypes()
        {
            return new List<GenderTypes>()
            {
                new GenderTypes { Gender = "woman/girl" },
                new GenderTypes { Gender = "man/boy" },
                new GenderTypes { Gender = "transwoman/transgirl" },
                new GenderTypes { Gender = "transman/transboy" },
                new GenderTypes { Gender = "non-binary/genderqueer/agender/gender fluid" },
                new GenderTypes { Gender = "don’t know" },
                new GenderTypes { Gender = "prefer not to say" },
                new GenderTypes { Gender = "other" }
            };
        }
    }
}