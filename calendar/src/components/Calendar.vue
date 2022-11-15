<template>
    <section class="day-table">
        <CalendarDay v-for="day in 30"
            :key="day"
            :day="day"
            :slotDate="`2022-11-${ day.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping: false}) }`"
        />
    </section>
</template>

<script setup lang="ts">
import axios from 'axios';
import { computed } from 'vue';
import CalendarDay from './CalendarDay.vue';

const dates = [
    '2022-11-01',
    '2022-11-02',
    '2022-11-03',
    '2022-11-04',
    '2022-11-05',
    '2022-11-06',
    '2022-11-07',
    '2022-11-08',
    '2022-11-09',
    '2022-11-10',
    '2022-11-11',
    '2022-11-12',
    '2022-11-13',
    '2022-11-14',
    '2022-11-15',
    '2022-11-16',
    '2022-11-17',
    '2022-11-18',
    '2022-11-19',
    '2022-11-20',
    '2022-11-21',
    '2022-11-22',
    '2022-11-23',
    '2022-11-24',
    '2022-11-25',
    '2022-11-26',
    '2022-11-27',
    '2022-11-28',
    '2022-11-29',
    '2022-11-30', 
]
// const busySlots = ref<number[]>([]);

// const paintBusiness = computed(async () => {
//     const baseUrl = 'https://localhost:7299/ReservedSlot/';

//     for (let i in dates) {
//         const response = await axios.get(`${baseUrl}${dates[i]}`);

//         for (let p in response.data) {
//         if (!busySlots.value.includes(response.data[p].index)){
//             busySlots.value.push(response.data[p].index);
//             console.log(busySlots);
//         }
//     }
//     }
// });
</script>

<style scoped>
.day-table {
    box-sizing: border-box;
    display: flex;
    flex-wrap: wrap;
    gap: 5px;
}
</style>