﻿global using Application.Common.Exceptions;
global using Application.Common.Interfaces;
global using Application.Common.Models;
global using Application.Features.TodoItems.Commands.CreateTodoItem;
global using Application.Features.TodoItems.Commands.DeleteTodoItem;
global using Application.Features.TodoItems.Commands.UpdateTodoItem;
global using Application.Features.TodoItems.Commands.UpdateTodoItemDetail;
global using Application.Features.TodoItems.DTOs;
global using Application.Features.TodoItems.Queries;
global using Application.Features.TodoLists.Commands.CreateTodoList;
global using Application.Features.TodoLists.Commands.DeleteTodoList;
global using Application.Features.TodoLists.Commands.UpdateTodoList;
global using Application.Features.TodoLists.Queries.GetTodos;
global using Application.Features.TodoLists.ViewModels;
global using Ardalis.GuardClauses;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Reflection;
global using System.Security.Claims;
global using WebAPI.Infras;
global using Azure.Identity;
global using Infrastructure.Data;
global using WebAPI.Services;
global using ZymLabs.NSwag.FluentValidation;
global using NSwag.Generation.Processors.Security;
global using NSwag;

