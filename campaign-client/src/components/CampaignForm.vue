<template>
  <div>
    <h2>Add Campaign</h2>

    <form @submit.prevent="submitCampaign">
      <div>
        <label>Name</label>
        <input v-model="campaign.name" type="text" required />
      </div>

      <div>
        <label>Start Date</label>
        <input v-model="campaign.startDate" type="date" required />
      </div>

      <div>
        <label>End Date</label>
        <input v-model="campaign.endDate" type="date" required />
      </div>
       <div>
        <label>
          <input v-model="campaign.active" type="checkbox" />
          Active
        </label>
      </div>
      <div class="actions">
        <button type="submit">Save Campaign</button>
        <router-link to="/">
            <button type="button" @click="cancel">Cancel</button>
        </router-link>
      </div>
    </form>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const campaign = ref({
  name: '',
  startDate: '',
  endDate: ''
})

async function submitCampaign() {
  try {
    const response = await fetch('https://localhost:7043/campaign', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(campaign.value)
    })

    if (!response.ok) {
      throw new Error('Failed to create campaign')
    }

    alert('Campaign created successfully')
    router.push('/')
  } catch (error) {
    console.error(error)
  }
}
</script>
<style scoped>
.actions {
  margin-top: 16px;
  display: flex;
  gap: 12px;
  justify-content: center;
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
.actions button[type="button"] {
  background: #6c757d;
  color: white;
}

.actions button[type="button"]:hover {
  background: #5a6268;
}
</style>