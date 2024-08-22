import { createRouter, createWebHistory } from 'vue-router';
import PriceCheck from '../components/PriceCheck.vue';
import HomePage from '../components/HomePage.vue';

const routes = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage,
  },
  {
    path: '/price-check',
    name: 'PriceCheck',
    component: PriceCheck,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;