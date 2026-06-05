<template>
    <div>
        <h2>Campaigns</h2>
        <div v-if="loading">
            Loading Campaigns...
        </div>
        <div v-else-if="error">
            {{ error }}
        </div>
        <table v-else class="campaigns-table">
            <thead>
                <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Start Date</th>
                <th>End Date</th>
                <th>Status</th>
                </tr>
            </thead>

            <tbody>
                <tr
                v-for="campaign in campaigns"
                :key="campaign.id"
                >
                    <td>{{ campaign.id }}</td>
                    <td>{{ campaign.name }}</td>
                    <td>{{ campaign.startDate }}</td>
                    <td>{{ campaign.endDate }}</td>
                    <td>
                        <div class="status-cell">
                        <span>{{ campaign.active ? "Active" : "Inactive" }}</span>

                            <label class="switch">  
                                <input
                                type="checkbox"
                                :checked="campaign.active"
                                @change="toggleActivation(campaign)"
                                />
                                <span class="slider"></span>
                            </label>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="actions">
            <router-link to="/campaigns/add">
                <button>
                    Add Campaign
                </button>
            </router-link>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'

const campaigns = ref([])
const loading = ref(false)
const error = ref(null)

async function fetchUsers() {
  loading.value = true
  error.value = null

  try {
    const response = await fetch(
      'https://localhost:7043/campaign'
    )

    if (!response.ok) {
      throw new Error('Failed to load users')
    }

    campaigns.value = await response.json()
  } catch (err) {
    error.value = err.message
  } finally {
    loading.value = false
  }
}

async function toggleActivation(campaign) {

  const newValue = !campaign.active;

  try {

    const response = await fetch(`https://localhost:7043/Campaign?id=${campaign.id}&active=${newValue}`, {
      method: 'PUT'
    })

    if (!response.ok) {
      throw new Error('Failed to update user')
    }

    campaign.active = newValue
  } catch (error) {
    console.error(error)
  }
}

onMounted(() => {
  fetchUsers()
})
</script>

<style scoped>
.campaigns-table {
  width: 100%;
  border-collapse: collapse;
}

.campaigns-table th,
.campaigns-table td {
  border: 1px solid #ddd;
  padding: 8px;
}

.status-cell {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 12px;
}

.switch {
  position: relative;
  width: 48px;
  height: 24px;
}

.switch input {
  display: none;
}

.slider {
  position: absolute;
  inset: 0;
  background: #ccc;
  border-radius: 24px;
  cursor: pointer;
  transition: 0.2s;
}

.slider::before {
  content: '';
  position: absolute;
  width: 18px;
  height: 18px;
  left: 3px;
  top: 3px;
  background: white;
  border-radius: 50%;
  transition: 0.2s;
}

input:checked + .slider {
  background: #42b883;
}

input:checked + .slider::before {
  transform: translateX(24px);
}

.actions {
  margin-top: 16px;
}

.actions button {
  padding: 8px 16px;
  background: #42b883;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.actions button:hover {
  background: #369870;
}
</style>