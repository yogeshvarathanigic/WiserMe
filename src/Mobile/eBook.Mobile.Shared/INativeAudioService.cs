namespace eBook.Mobile.Shared;

public interface INativeAudioService
{
    Task InitializeAsync(string audioUri);

    Task PlayAsync(double position = 0);

    Task PauseAsync();

    Task SetMuted(bool value);

    Task SetVolume(int value);

    Task SetCurrentTime(double value);

    ValueTask DisposeAsync();

    bool IsPlaying { get; }

    double CurrentPosition { get; }

    event EventHandler<bool> IsPlayingChanged;
}