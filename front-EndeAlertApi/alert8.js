


document.getElementById('alertButton').addEventListener('click', async () => {
  const statusDiv = document.getElementById('status');
  statusDiv.textContent = 'Triggering alert...';

  try {
      // Captura da localização
      const location = await new Promise((resolve, reject) => {
          navigator.geolocation.getCurrentPosition(resolve, reject, { timeout: 10000 });
      });

      // Captura de áudio e vídeo
      const stream = await navigator.mediaDevices.getUserMedia({ audio: true, video: true });

      // Gravação de vídeo e áudio
      const mediaRecorder = new MediaRecorder(stream);
      const chunks = [];

      mediaRecorder.ondataavailable = function(e) {
          chunks.push(e.data);
      };

      mediaRecorder.onstop = async function(e) {
          const blob = new Blob(chunks, { type: 'video/mp4' });
          const formData = new FormData();
          formData.append('video', blob, 'alert_video.mp4');
          formData.append('location', JSON.stringify({
              latitude: location.coords.latitude,
              longitude: location.coords.longitude
          }));

          // Envia os dados para a API
          try {
              const response = await fetch('https://localhost:7167/api/Alert/trigger', {
                  method: 'POST',
                  body: formData
              });

              if (response.ok) {
                  statusDiv.textContent = 'Alert sent successfully!';
              } else {
                  const errorData = await response.json();
                  statusDiv.textContent = 'Failed to send alert. Error: ' + errorData.errors.video[0];
              }
          } catch (error) {
              statusDiv.textContent = 'Failed to send alert. Error: ' + error.message;
          }
      };

      // Inicia a gravação e para após 5 segundos
      mediaRecorder.start();
      setTimeout(() => {
          mediaRecorder.stop();
      }, 5000);
  } catch (error) {
      console.error('Error capturing data', error);
      statusDiv.textContent = 'Error capturing data: ' + error.message;
  }
});
