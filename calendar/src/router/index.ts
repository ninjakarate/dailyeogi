import { createRouter, createWebHistory } from 'vue-router'
import CalendarView from '@/views/CalendarView.vue'
import SlotsView from '@/views/SlotsView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: CalendarView,
        },
        {
            path: '/slot/:slotDate',
            name: 'slot-view',
            component: SlotsView,

            props: true,
        },
    ]
})

export default router
