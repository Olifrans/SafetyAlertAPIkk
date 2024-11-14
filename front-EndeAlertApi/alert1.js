

//Este é o código JavaScript que captura a localização, áudio, vídeo e envia para a API

document.getElementById("alertButton").addEventListener("click", async () => {
  try {
    // Captura da localização
    const location = await new Promise((resolve, reject) => {
      navigator.geolocation.getCurrentPosition(resolve, reject);
    });

    // Captura de áudio e vídeo
    const stream = await navigator.mediaDevices.getUserMedia({
      audio: true,
      video: true,
    });

    // Gravação de vídeo e áudio (limitado a poucos segundos para exemplo)
    const mediaRecorder = new MediaRecorder(stream);
    const chunks = [];

    mediaRecorder.ondataavailable = function (e) {
      chunks.push(e.data);
    };

    mediaRecorder.onstop = async function (e) {
      const blob = new Blob(chunks, { type: "video/mp4;" });
      const formData = new FormData();
      formData.append(
        "location",
        JSON.stringify({
          latitude: location.coords.latitude,
          longitude: location.coords.longitude,
        })
      );
      formData.append("video", blob);


      // Envia os dados para a API
      await fetch("http://localhost:5129/api/Alert/trigger", {
      // await fetch("https://localhost:44368/api/Alert/trigger", {

        method: "POST",
        body: formData,
      });

      alert("Alerta de emrgencia enviado com sucesso!!");
    };

    // Inicia a gravação
    mediaRecorder.start();

    // Para a gravação após 5 segundos
    setTimeout(() => {
      mediaRecorder.stop();
    }, 3500);
  } catch (error) {
    console.error("Erro ao capturar dados", error);
  }
});

