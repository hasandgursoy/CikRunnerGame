using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _orientationTransform;
    [SerializeField] private Transform _playerVisualTransform;
    [Header("settings")]
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        // Kamera ile karakter arasındaki yatay mesafe
        // Baktımığız pozisyonu aldık.
        Vector3 viewDirecton = _playerTransform.position - new Vector3(Camera.main.transform.position.x, _playerTransform.position.y, Camera.main.transform.position.z);

        // Kamera karakteri takip etsin
        // Yalnızca yatay düzlemde döndür
        _orientationTransform.forward = viewDirecton.normalized;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Karakterin hareket yönü
        Vector3 inputDirection = _orientationTransform.forward * verticalInput + _orientationTransform.right * horizontalInput;

        // Eğer karakter duruyorsa döndürme işlemi yapma
        if (inputDirection != Vector3.zero)
        {
            // Karakterin görsel modelini hareket yönüne doğru döndür
            _playerVisualTransform.forward = Vector3.Slerp(_playerVisualTransform.forward, inputDirection.normalized, Time.deltaTime * _rotationSpeed);
        }
        // Karakterin görsel modelini hareket yönüne doğru döndür
        // Slerp ile yumuşak geçiş sağla
        // Slerp şu işe yarar iki yön arasındaki açıyı yumuşak bir şekilde döndürür
        // Deltatime ile frame rate bağımsız hale getirir bu da bize her bilgisayarda aynı hızda çalışmasını sağlar


        /*Genel olarak bu dosya da detaylı olarak açıklarsak ; 
        1. Kamera ile karakter arasındaki yatay mesafe hesaplanır.
        2. Kamera, karakteri takip eder ve yalnızca yatay düzlemde döner.
        3. Kullanıcı girdileri alınır ve karakterin hareket yönü hesaplanır.
        4. Eğer karakter duruyorsa döndürme işlemi yapılmaz.
        5. Karakterin görsel modeli, hareket yönüne doğru yumuşak bir şekilde döndürülür.
        */

    }
}
