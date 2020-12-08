﻿using TIMSBack.Application.Common.Exceptions;
using TIMSBack.Application.TodoItems.Commands.CreateTodoItem;
using TIMSBack.Application.TodoItems.Commands.UpdateTodoItem;
using TIMSBack.Application.TodoItems.Commands.UpdateTodoItemDetail;
using TIMSBack.Application.TodoLists.Commands.CreateTodoList;
using TIMSBack.Domain.Entities;
using TIMSBack.Domain.Enums;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace TIMSBack.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class UpdateTodoItemDetailTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdateTodoItemCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            var command = new UpdateTodoItemDetailCommand
            {
                Id = itemId,
                ListId = listId,
                Note = "This is the note.",
                Priority = PriorityLevel.High
            };

            await SendAsync(command);

            var item = await FindAsync<TodoItem>(itemId);

            item.ListId.Should().Be(command.ListId);
            item.Note.Should().Be(command.Note);
            item.Priority.Should().Be(command.Priority);
            //item.LastModifiedBy.Should().NotBeNull();
            //item.LastModifiedBy.Should().Be(userId);
            //item.LastModified.Should().NotBeNull();
            //item.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
