﻿using MyCompanyInThePocket.Core.Models;
using MyCompanyInThePocket.Core.Repositories.Interfaces;
using MyCompanyInThePocket.Core.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompanyInThePocket.Core.Services
{
    internal class MeetingsService : IMeetingService
    {
        private readonly IOnlineMeetingRepository _onlineMeetingReposity;

        public MeetingsService(IOnlineMeetingRepository onlineMeetingReposity)
        {
            _onlineMeetingReposity = onlineMeetingReposity;
        }

        private bool HasConnectivity
        {
            get
            {
                return Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
            }
        }

        public async Task<List<Meeting>> GetMeetingsAsync()
        {
            var onlineRepository = _onlineMeetingReposity;

            List<Meeting> meetings = null;
            if (HasConnectivity)
            {
                meetings = await onlineRepository.GetMeetingAsync();
            }

            // TODO : mettre à jour la bdd et lire les données
            return meetings;
        }
    }
}
