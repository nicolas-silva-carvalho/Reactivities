using System;
using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Activities.Any()) return;

        var activities = new List<Activity>
        {
            new Activity
            {
                Title = "Passeio no Parque",
                Description = "Caminhada leve e piquenique com amigos.",
                Category = "Lazer",
                City = "Fortaleza",
                Venue = "Parque do Cocó",
                Date = DateTime.UtcNow.AddDays(5),
                Latitute = -3.745,
                Longitude = -38.489,
                IsCanceled = false
            },
            new Activity
            {
                Title = "Workshop de Programação",
                Description = "Evento introdutório sobre desenvolvimento em C# e .NET.",
                Category = "Tecnologia",
                City = "São Paulo",
                Venue = "Centro de Inovação SP",
                Date = DateTime.UtcNow.AddDays(12),
                Latitute = -23.5558,
                Longitude = -46.6396,
                IsCanceled = false
            },
            new Activity
            {
                Title = "Aula de Yoga ao Ar Livre",
                Description = "Sessão de yoga para iniciantes ao ar livre.",
                Category = "Saúde",
                City = "Recife",
                Venue = "Praia de Boa Viagem",
                Date = DateTime.UtcNow.AddDays(3),
                Latitute = -8.111,
                Longitude = -34.882,
                IsCanceled = false
            },
            new Activity
            {
                Title = "Feira de Empreendedorismo",
                Description = "Exposição de produtos locais e palestras sobre negócios.",
                Category = "Negócios",
                City = "Curitiba",
                Venue = "Expo Curitiba",
                Date = DateTime.UtcNow.AddDays(20),
                Latitute = -25.4284,
                Longitude = -49.2733,
                IsCanceled = false
            },
            new Activity
            {
                Title = "Corrida de Rua 10K",
                Description = "Prova de 10 quilômetros aberta ao público.",
                Category = "Esporte",
                City = "Rio de Janeiro",
                Venue = "Aterro do Flamengo",
                Date = DateTime.UtcNow.AddDays(15),
                Latitute = -22.9068,
                Longitude = -43.1729,
                IsCanceled = false
            },
            new Activity
            {
                Title = "Festival de Música",
                Description = "Shows de bandas locais e food trucks.",
                Category = "Entretenimento",
                City = "Salvador",
                Venue = "Parque da Cidade",
                Date = DateTime.UtcNow.AddDays(30),
                Latitute = -12.9714,
                Longitude = -38.5014,
                IsCanceled = false
            }
        };

        context.Activities.AddRange(activities);
        await context.SaveChangesAsync();
    }
}
