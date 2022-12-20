using P1_ASP.Models;

namespace P1_ASP.Services
{
    public class RepositoryOfFormaciones
    {
        public List<ClassProjects> GetProjects()
        {
            return new List<ClassProjects>() 
            {
                new ClassProjects {
                    Title = "Memory",
                    Description = "Juego realizado con C#",
                    Link = "https://amazon.com",
                    ImageURL = "/images/memory.png"
                },
                new ClassProjects {
                    Title = "Calculadora",
                    Description = "Calculador hecha con Java",
                    Link = "https://Monlau.com",
                    ImageURL = "/images/logoASP.png"
                },
                new ClassProjects {
                    Title = "Concurso",
                    Description = "Concurso realizado con JavaScript",
                    Link = "https://Monlau.com",
                    ImageURL = "/images/conurso.png"
                },
                new ClassProjects {
                    Title = "Portafolo",
                    Description = "Web relizada con HTML y CSS",
                    Link = "https://Monlau.com",
                    ImageURL = "/images/logoASP.png"
                },
                new ClassProjects {
                    Title = "Zonas horarias",
                    Description = "Web para visualizar la hora y la fecha en direfentes zonas horarias de Europa relizado con JavaScript",
                    Link = "https://Monlau.com",
                    ImageURL = "/images/logoASP.png"
                },
                new ClassProjects {
                    Title = "Leyes de Gestalt",
                    Description = "Pagina relizada con CSS y HTML",
                    Link = "https://Monlau.com",
                    ImageURL = "/images/logoASP.png"
                }
            };
        }

    }
}
