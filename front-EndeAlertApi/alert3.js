



// //Este é o código JavaScript que captura a localização, áudio, vídeo e envia para a API

// document.getElementById('alertButton').addEventListener('click', async () => {
//     const statusDiv = document.getElementById('status');
//     statusDiv.textContent = 'Triggering alert...';

//     try {
//         // Captura da localização
//         const location = await new Promise((resolve, reject) => {
//             navigator.geolocation.getCurrentPosition(resolve, reject);
//         });

//         // Captura de áudio e vídeo
//         const stream = await navigator.mediaDevices.getUserMedia({ audio: true, video: true });

//         // Gravação de vídeo e áudio
//         const mediaRecorder = new MediaRecorder(stream);
//         const chunks = [];

//         mediaRecorder.ondataavailable = function(e) {
//             chunks.push(e.data);
//         };

//         mediaRecorder.onstop = async function(e) {
//             const blob = new Blob(chunks, { 'type': 'video/mp4;' });
//             const formData = new FormData();
//             formData.append('location', JSON.stringify({
//                 latitude: location.coords.latitude,
//                 longitude: location.coords.longitude
//             }));
//             formData.append('video', blob);

//             // Envia os dados para a API
//             const response = await fetch('https://localhost:7167/api/alert/trigger', {
//                 method: 'POST',
//                 body: formData
//             });

//             if (response.ok) {
//                 statusDiv.textContent = 'Alert sent successfully!';
//             } else {
//                 statusDiv.textContent = 'Failed to send alert.';
//             }
//         };

//         // Inicia a gravação e para após 5 segundos
//         mediaRecorder.start();
//         setTimeout(() => {
//             mediaRecorder.stop();
//         }, 5000);
//     } catch (error) {
//         console.error('Error capturing data', error);
//         statusDiv.textContent = 'Error capturing data: ' + error.message;
//     }
// });


/*

Explicação:

O frontend captura a localização e o vídeo.
Esses dados são enviados como FormData para a API através do método fetch.
A API recebe o vídeo e a localização, e armazena essas informações.

 */











//O arquivo JavaScript que captura localização, áudio, vídeo, e envia os dados para a API:
document.getElementById('alertButton').addEventListener('click', async () => {
    const statusDiv = document.getElementById('status');
    statusDiv.textContent = 'Triggering alert...';

    try {
        // Captura da localização
        const location = await new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition(resolve, reject);
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
            const blob = new Blob(chunks, { 'type': 'video/mp4;' });
            const formData = new FormData();
            formData.append('location', JSON.stringify({
                latitude: location.coords.latitude,
                longitude: location.coords.longitude
            }));
            formData.append('video', blob);

            // Envia os dados para a API
            const response = await fetch('https://localhost:7167/api/alert/trigger', {
                method: 'POST',
                body: formData
            });

            if (response.ok) {
                statusDiv.textContent = 'Alert sent successfully!';
            } else {
                statusDiv.textContent = 'Failed to send alert.';
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
