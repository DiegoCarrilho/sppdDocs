﻿using System;
using Moq;
using SppdDocs.Core.Entities.BasketAggregate;
using SppdDocs.Core.Exceptions;
using SppdDocs.Core.Interfaces;
using SppdDocs.Core.Services;
using Xunit;

namespace SppdDocs.UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class SetQuantities
    {
        private int _invalidId = -1;
        private Mock<IAsyncRepository<Basket>> _mockBasketRepo;

        public SetQuantities()
        {
            _mockBasketRepo = new Mock<IAsyncRepository<Basket>>();
        }

        [Fact]
        public async void ThrowsGivenInvalidBasketId()
        {
            var basketService = new BasketService(_mockBasketRepo.Object, null, null, null);

            await Assert.ThrowsAsync<BasketNotFoundException>(async () =>
                await basketService.SetQuantities(_invalidId, new System.Collections.Generic.Dictionary<string, int>()));
        }

        [Fact]
        public async void ThrowsGivenNullQuantities()
        {
            var basketService = new BasketService(null, null, null, null);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await basketService.SetQuantities(123, null));
        }

    }
}