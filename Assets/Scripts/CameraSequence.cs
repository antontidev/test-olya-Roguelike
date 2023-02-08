using DG.Tweening;
using Services;

public class CameraSequence {
    private readonly CameraBlendService _cameraBlendService;
    private readonly CameraBlendSettings _cameraBlendSettings;
    private readonly Sequence _sequence;

    public CameraSequence(CameraBlendService cameraBlendService,
        CameraBlendSettings cameraBlendSettings) {
        _cameraBlendService = cameraBlendService;
        _cameraBlendSettings = cameraBlendSettings;

        _sequence = DOTween.Sequence();
    }

    public CameraSequence AppendHeroSwitch() {
        _sequence
            .AppendInterval(_cameraBlendSettings.Delay)
            .AppendCallback(() => _cameraBlendService.SwitchToHeroCamera());
            
        return this;
    }

    public CameraSequence AppendEnemySwitch() {
        _sequence
            .AppendInterval(_cameraBlendSettings.Delay)
            .AppendCallback(() => _cameraBlendService.SwitchToEnemyCamera());

        return this;
    }

    public CameraSequence AppendMainSwitch() {
        _sequence
            .AppendInterval(_cameraBlendSettings.Delay)
            .AppendCallback(() => _cameraBlendService.SwitchToMainCamera());
            
        return this;
    }
}