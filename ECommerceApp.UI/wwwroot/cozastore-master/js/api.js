const API_BASE = 'https://localhost:7154/api';

async function getProducts() {
    const response = await fetch(`${API_BASE}/Product`);
    if (!response.ok) {
        throw new Error('Failed to fetch products');
    }
    return response.json();
}