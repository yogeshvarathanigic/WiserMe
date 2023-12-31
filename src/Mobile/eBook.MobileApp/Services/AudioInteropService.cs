﻿using System.Timers;
using eBook.Components;
using eBook.Mobile.Shared;
using eBook.Pages.Data;
using Microsoft.AspNetCore.Components;

namespace eBook.MobileApp.Services;

internal class AudioInteropService : IAudioInterop
{
    private readonly INativeAudioService _nativeAudioService;
    private readonly PlayerService _playerService;
    private readonly System.Timers.Timer _currentTimeTimer;

    public AudioInteropService(
        INativeAudioService nativeAudioService,
        PlayerService playerService)
    {
        _nativeAudioService = nativeAudioService;
        _playerService = playerService;

        _currentTimeTimer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
        _currentTimeTimer.Elapsed += OnCurrentTimeEvent;
    }

    public Task PauseAsync(ElementReference element)
    {
        return _nativeAudioService.PauseAsync();
    }

    public async Task PlayAsync(ElementReference element)
    {
        await _nativeAudioService.PlayAsync(_nativeAudioService.CurrentPosition);
    }

    public async Task SetCurrentTimeAsync(ElementReference element, double value)
    {
        await _nativeAudioService.SetCurrentTime(value);
    }

    public Task SetMutedAsync(ElementReference element, bool value)
    {
        return _nativeAudioService.SetMuted(value);
    }

    public void SetUri(string audioURI)
    {
        if (audioURI != null)
        {
            _nativeAudioService.InitializeAsync(audioURI).Wait();
            _currentTimeTimer.Start();
        }
    }

    public Task SetVolumeAsync(ElementReference element, int value)
    {
        return _nativeAudioService.SetVolume(value);
    }

    public Task StopAsync(ElementReference element)
    {
        return _nativeAudioService.PauseAsync();
    }

    public ValueTask DisposeAsync()
    {
        _currentTimeTimer.Dispose();
        return _nativeAudioService.DisposeAsync();
    }

    private void OnCurrentTimeEvent(object source, ElapsedEventArgs e)
    {
        _playerService.CurrentTime = _nativeAudioService.CurrentPosition;
    }

    public Task SetPlaybackRateAsync(ElementReference element, double value)
    {
        Console.WriteLine($"{nameof(AudioInterop)}.{nameof(SetPlaybackRateAsync)} is not implemented for this platform.");
        return Task.CompletedTask;
    }
}
