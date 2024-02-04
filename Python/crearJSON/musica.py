import os
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

def detectar_ritmo(y, sr):
    Y = np.abs(librosa.stft(y))
    E = np.sum(Y**2, axis=0)
    ritmo = np.argmax(E)
    return ritmo

audio_file_path = r"20.mp3"

y, sr = librosa.load(audio_file_path, mono=True)

y_preemphasis = librosa.effects.preemphasis(y)
onset_envelope = librosa.onset.onset_strength(y=y_preemphasis, sr=sr)
onsets = librosa.onset.onset_detect(onset_envelope=onset_envelope, sr=sr)
onset_times = np.where(onsets)[0]
energia_promedio = np.mean(onset_envelope)
carriles = [asignar_a_carril(energia / energia_promedio) for energia in onset_envelope[onset_times]]
colores_carriles = {"verde": "green", "rojo": "red", "amarillo": "yellow", "azul": "blue", "naranja": "orange"}
audio_filename = os.path.basename(audio_file_path)
json_filename = os.path.splitext(audio_file_path)[0] + '.json'
ritmo = detectar_ritmo(y, sr)
velocidades = [tiempo / ritmo for tiempo in onset_times]

# Calcular la duración de la canción
duracion_cancion = librosa.get_duration(filename=audio_file_path)

# Contar el número de transientes únicos
num_transientes = len(set(onset_times))

# Calcular la duración de cada nota
duracion_nota = duracion_cancion / num_transientes

# Calcular el tiempo en segundos desde el inicio de la canción hasta que suena cada nota
tiempos_notas = [duracion_nota * i for i in range(num_transientes)]

# Generar una lista de transientes de 0 a 128
transientes = list(range(129))

# Exportar los datos a un archivo JSON
data = {
    "transientes": transientes,
    "carriles": carriles,
    "ritmo": ritmo,
    "velocidades": velocidades,
    "duracion_cancion": duracion_cancion,
    "tiempos_notas": tiempos_notas,
}
with open(json_filename, 'w') as f:
    json.dump(data, f, cls=NumpyEncoder, indent=4)

# Visualizar los transientes en los carriles
plt.figure(figsize=(12, 4))
for i, carril in enumerate(carriles):
    plt.plot(i, onset_times[i], 'o', color=colores_carriles[carril], label=carril)

plt.legend()
plt.yticks(range(len(carriles)), carriles)
plt.xlabel('Transientes')
plt.title('Asignación de Transientes a Carriles')
plt.show()
