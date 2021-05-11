using AutoMapper;
using MasAcademyLab.Data.Repositories;
using MasAcademyLab.Domain;
using MasAcademyLab.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasAcademyLab.Service
{
    public class TalkService : ITalkService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly ITalkRepository _talkRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IMapper _mapper;

        public TalkService(ITrainingRepository trainingRepository,ITalkRepository talkRepository, ISpeakerRepository speakerRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _talkRepository = talkRepository;
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TalkModel>> GetTalksAsync(string code, bool includeSpeakers = false)
        {
            try
            {
                var talks = await _talkRepository.GetTalksByCodeAsync(code, includeSpeakers);

                return _mapper.Map<IEnumerable<TalkModel>>(talks);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TalkModel> GetTalkAsync(string code, int talkId, bool includeSpeakers = false)
        {
            try
            {
                var talk = await _talkRepository.GetTalkByCodeAsync(code, talkId, includeSpeakers);

                return _mapper.Map<TalkModel>(talk);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TalkModel> CreateTalkAsync(string code, TalkCreationModel talkModel)
        {
            try
            {
                var training = await _trainingRepository.GetTrainingAsync(code);

                var talk = _mapper.Map<Talk>(talkModel);

                if (talkModel.Speaker != null)
                {
                    var speaker = await _speakerRepository.GetSpeakerAsync(talkModel.Speaker.SpeakerId);

                    if (speaker != null)
                    {
                        talk.SpeakerId = speaker.SpeakerId;
                        talk.Speaker = speaker;
                    }
                }                

                talk.Training = training;
                _talkRepository.Add(talk);

                await _talkRepository.SaveChangesAsync();
                return _mapper.Map<TalkModel>(talk);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TalkModel> UpdateTalkAsync(string code, int talkId, TalkUpdateModel talkModel)
        {
            try
            {
                var oldTalk = await _talkRepository.GetTalkByCodeAsync(code, talkId);

                _mapper.Map(talkModel, oldTalk);

                if (talkModel.Speaker != null)
                {
                    var speaker = await _speakerRepository.GetSpeakerAsync(talkModel.Speaker.SpeakerId);
                    if(speaker != null)
                    {
                        oldTalk.SpeakerId = speaker.SpeakerId;
                        oldTalk.Speaker = speaker;
                    }
                }

                await _talkRepository.SaveChangesAsync();
                return _mapper.Map<TalkModel>(oldTalk);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteTalkAsync(string code, int talkId)
        {
            var oldTalk = await _talkRepository.GetTalkByCodeAsync(code, talkId);

            if (oldTalk != null)
            {
                _talkRepository.Delete(oldTalk);

                await _talkRepository.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(string code, int talkId)
        {
            try
            {
                var talk = await _talkRepository.GetTalkByCodeAsync(code, talkId);

                return talk != null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
