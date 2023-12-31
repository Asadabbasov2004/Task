﻿using First_Api.Entities;
using First_Api.Repositories.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using First_Api.DTOs.CardDTOs;
using System.Linq.Expressions;
using First_Api.DAL;

namespace First_Api.Repositories.Implementation
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IQueryable<Brand>> GetAll(Expression<Func<Brand, bool>>? expression = null, params string[] includes)
        {
            IQueryable<Brand> query = _context.Brands;
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (expression is not null)
            {
                query = query.Where(expression);

            }
            return query;
        }

        public async Task<Brand> GetById(int id)
        {
            return await _context.Brands.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task Create(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
        }

        public void Delete(Brand brand)
        {
            _context.Brands.Remove(brand);
        }
        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<IQueryable<Car>> GetAll(Expression<Func<Car, bool>>? expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        Task<Car> ICarRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Create(Car brand)
        {
            throw new NotImplementedException();
        }

        public void Update(Car brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car brand)
        {
            throw new NotImplementedException();
        }
    }
}
