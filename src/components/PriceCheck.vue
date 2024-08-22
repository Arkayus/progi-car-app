<template>
    <div>
        <div class="row justify-content-center">
            <div class="col-4">
                <h1>Price Check</h1>
                <p>Check the prices here!</p>
                <br>

                <label for="vehiculePrice" class="form-label">Vehicule base price</label>
                <input v-model.number="vehiculeValue" type="text" class="form-control" id="vehiculePrice" aria-describedby="priceHelp">
                <div id="priceHelp" class="form-text">Please enter the exact base price.</div>

                <br>

                <label for="vehiculeType" class="form-label">Vehicule type</label>
                <select v-model.number="vehiculeType" class="form-select" id="vehiculeType" aria-label="Default select example">
                    <option value="1">Common</option>
                    <option value="2">Luxury</option>
                </select>

                <br>

                <span>Basic fees: </span><span>{{ result?.basicFee }} $</span>
                <br>
                <span>Special fees: </span><span>{{ result?.specialFee }} $</span>
                <br>
                <span>Association fees: </span><span>{{ result?.associationFee }} $</span>
                <br>
                <span>Storage fees: </span><span>{{ result?.storageFee }} $</span>
            </div>
        </div>
    </div>
  </template>
  
<script lang="ts">
    import { defineComponent, ref, watch } from 'vue';
    import axios, { AxiosError } from 'axios';
    import { PriceCheckReturn } from '@/Interfaces/PriceCheckReturn';

    export default defineComponent({
        name: "PriceCheck",
        setup() {
            const vehiculeValue = ref<number>(0);
            const vehiculeType = ref<number>(1);
            const result = ref<PriceCheckReturn | null>(null);

            watch([vehiculeValue, vehiculeType], async () => {
                await calculateFinalPrice();
            });

            async function calculateFinalPrice() {
                try {
                    const requestData = {
                        VehiculeBasePrice: vehiculeValue.value,
                        VehiculeType: vehiculeType.value,
                    };

                    const response = await axios.post('http://localhost:5242/api/VehiculeFees', requestData);
                    const data: PriceCheckReturn = response.data;
                    result.value = data
                } catch (error) {
                    // Handle different error types
                    if (axios.isAxiosError(error)) {
                    // Handle Axios errors
                    const axiosError = error as AxiosError;
                    console.error('Response error data:', axiosError.response?.data);
                    console.error('Response error status:', axiosError.response?.status);
                    console.error('Response error headers:', axiosError.response?.headers);
                    } else if (error instanceof Error) {
                    // Handle generic errors
                    console.error('Error message:', error.message);
                    } else {
                    // Handle unexpected errors
                    console.error('Unexpected error:', error);
                    }
                }
            }

            // Initial calculation when the component is mounted
            calculateFinalPrice();

            return {
                vehiculeValue,
                vehiculeType,
                result,
            };
        },
    })
</script>