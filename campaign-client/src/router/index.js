import { createRouter, createWebHistory } from 'vue-router'
import CampaignTable from '@/components/CampaignTable.vue'
import CampaignForm from '@/components/CampaignForm.vue'

const routes = [
  {
    path: '/',
    name: 'Campaigns',
    component: CampaignTable
  },
  {
    path: '/campaigns/add',
    name: 'Add Campaign',
    component: CampaignForm
  }
]

export default createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})