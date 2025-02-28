﻿global using Application.Common.Behaviours;
global using Application.Common.Exceptions;
global using Application.Common.Extensions;
global using Application.Common.Interfaces;
global using Application.Common.Models;
global using Application.Common.Security;
global using Application.Features.TodoItems.Commands.CreateTodoItem;
global using Application.Features.TodoItems.Commands.DeleteTodoItem;
global using Application.Features.TodoItems.Commands.UpdateTodoItem;
global using Application.Features.TodoItems.Commands.UpdateTodoItemDetail;
global using Application.Features.TodoItems.DTOs;
global using Application.Features.TodoItems.Queries;
global using Application.Features.TodoLists.Commands.CreateTodoList;
global using Application.Features.TodoLists.Commands.DeleteTodoList;
global using Application.Features.TodoLists.Commands.PurgeTodoLists;
global using Application.Features.TodoLists.Commands.UpdateTodoList;
global using Application.Features.TodoLists.DTOs;
global using Application.Features.TodoLists.Queries.GetTodos;
global using Application.Features.TodoLists.ViewModels;
global using Application.Features.WeatherForecasts.Queries;
global using Ardalis.GuardClauses;
global using AutoMapper;
global using AutoMapper.QueryableExtensions;
global using Domain.Constants;
global using Domain.Entities;
global using Domain.Enums;
global using Domain.Events;
global using FluentValidation;
global using FluentValidation.Results;
global using MediatR;
global using MediatR.Pipeline;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Shared.Extensions;
global using Shared.Resources;
global using System.Diagnostics;
global using System.Reflection;
global using System.Text.Json.Serialization;
