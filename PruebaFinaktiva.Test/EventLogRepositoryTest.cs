using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NUnit.Framework;
using PruebaFinaktiva.Api.Controllers;
using PruebaFinaktiva.Api.Interfaces;
using PruebaFinaktiva.Api.Repository;
using PruebaFinaktiva.Data;
using PruebaFinaktiva.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaFinaktiva.Tests.Repository
{
    public class EventLogRepositoryTests
    {

        private readonly DbContextOptions<DataContext> _options;
        private readonly Mock<IEventLogProvider> _unitOfWorkMock;

        public EventLogRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _unitOfWorkMock = new Mock<IEventLogProvider>();
        }

        [Test]
        public async Task AddLogAsync_Successful()
        {
            // Arrange
            using DataContext context = new(_options);
            var eventLogRepository = new EventLogRepository(context);
            EventLog eventLog = new EventLog
            {
                Id = 1,
                EventType = "Api",
                EventDate = DateTime.UtcNow,
                EventDescription = "Prueba 1"
            };

            string result;

            // Act
            result = await eventLogRepository.AddLogAsync(eventLog);

            // Assert
            Assert.AreEqual("Registro guardado con exito", result.ToString());
            Assert.IsNotNull(result);

            //Clean 
            context.Database.EnsureDeleted();
            context.Dispose();
        }


        [Test]
        public async Task AddLogAsync_Faill()
        {
            // Arrange
            using DataContext context = new(_options);
            var eventLogRepository = new EventLogRepository(context);
            EventLog eventLog = new EventLog { Id = 1,
                                               EventType = "Api", 
                                               EventDate = DateTime.UtcNow, 
                                               EventDescription = "Prueba 1" };
            string result;
            await eventLogRepository.AddLogAsync(eventLog);              

            // Act
            //Se agrega por segunda vez para que salga el error por el mismo id
            result = await eventLogRepository.AddLogAsync(eventLog);

            // Assert
            Assert.AreEqual("[Error:] Ocurrio un error al guardar el registro, intentelo mas tarde o comuniquiese con el administrador del sistema", result.ToString());
            Assert.IsNotNull(result);

            //Clean 
            context.Database.EnsureDeleted();
            context.Dispose();
        }


        [Test]
        public async Task GetAllAsync_Successful()
        {
            // Arrange
            using DataContext context = new(_options);
            var eventLogRepository = new EventLogRepository(context);
            EventLog eventLog = new EventLog
            {
                Id = 1,
                EventType = "Api",
                EventDate = DateTime.UtcNow,
                EventDescription = "Prueba 1"
            };

            // Act
            await eventLogRepository.AddLogAsync(eventLog);
            List<EventLog> result = await eventLogRepository.GetAllAsync();

            // Assert            
            Assert.IsNotEmpty(result);

            //Clean 
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task GetEventsByFilters_WithParams_Successful()
        {
            // Arrange
            using DataContext context = new(_options);
            var eventLogRepository = new EventLogRepository(context);
            DateTime actualDate = DateTime.UtcNow;
            EventLog eventLog = new EventLog
            {
                Id = 1,
                EventType = "Api",
                EventDate = actualDate,
                EventDescription = "Prueba 1"
            };

            // Act
            await eventLogRepository.AddLogAsync(eventLog);
            List<EventLog> result = await eventLogRepository.GetEventsByFilters("Api", actualDate.AddDays(-1), actualDate.AddDays(1));

            // Assert            
            Assert.IsNotEmpty(result);

            //Clean 
            context.Database.EnsureDeleted();
            context.Dispose();
        }

    }
}
