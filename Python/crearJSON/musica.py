import librosa
import numpy as np
import matplotlib.pyplot as plt
import json
from scipy.signal import butter, lfilter

class NumpyEncoder(json.JSONEncoder):
    def default(self, obj):
        if isinstance(obj, np.integer):
            return int(obj)
        elif isinstance(obj, np.ndarray):
            return obj.tolist()
        return super(NumpyEncoder, self).default(obj)

def asignar_a_carril(transiente):
    total_carriles = 5
    carril = int(transiente * total_carriles)
    if carril >= total_carriles:
        carril = total_carriles - 1
    return ["verde", "rojo", "amarillo", "azul", "naranja"][carril]

audio_file_path = r"..\cancionesMP3\aa.mp3"

y, sr = librosa.load(audio_file_path, mono=True)

# Pre-enfatizar la señal
y_preemphasis = librosa.effects.preemphasis(y)

# Calcular la envolvente de fuerza de onset
onset_envelope = librosa.onset.onset_strength(y=y_preemphasis, sr=sr)

# Calcular los onsets
onsets = librosa.onset.onset_detect(onset_envelope=onset_envelope, sr=sr)

# Obtener los índices de los onsets
onset_times = np.where(onsets)[0]

# Calcular la energía promedio de cada transiente
energia_promedio = np.mean(onset_envelope)

# Asignar cada transiente a un carril basándose en su energía relativa
carriles = [asignar_a_carril(energia / energia_promedio) for energia in onset_envelope[onset_times]]

# Definir un diccionario que mapee los nombres de los carriles a valores de color
colores_carriles = {"verde": "green", "rojo": "red", "amarillo": "yellow", "azul": "blue", "naranja": "orange"}

# Calcular los intervalos de tiempo entre los onsets
onset_intervals = np.diff(onset_times)

# Convertir los intervalos de tiempo a segundos
onset_intervals_seconds = onset_intervals / sr

# Exportar los datos a un archivo JSON
data = {
    "transientes": onset_times.tolist(),
    "carriles": carriles,
    "onset_intervals": onset_intervals_seconds.tolist(),
}
with open('data.json', 'w') as f:
    json.dump(data, f, cls=NumpyEncoder)

# Visualizar los transientes en los carriles
plt.figure(figsize=(12, 4))
for i, carril in enumerate(carriles):
    plt.plot(i, onset_times[i], 'o', color=colores_carriles[carril], label=carril)

plt.legend()
plt.yticks(range(len(carriles)), carriles)
plt.xlabel('Transientes')
plt.title('Asignación de Transientes a Carriles')
plt.show()
