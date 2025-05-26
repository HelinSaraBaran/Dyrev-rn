using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Service
{
    public class ActivitySignupService
    {
        private IActivitySignupRepository _repository;

        public ActivitySignupService()
        {
            _repository = new ActivitySignupRepository();
        }

        public void AddSignup(ActivitySignup signup)
        {
            _repository.Add(signup);
        }

        public List<ActivitySignup> GetAllSignups()
        {
            return _repository.GetAll();
        }

        public void SaveAll(List<ActivitySignup> signups)
        {
            _repository.SaveAll(signups);
        }
    }
}
