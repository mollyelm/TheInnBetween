import 'dotenv/config';
import pg from "pg";

const { Client } = pg;

const client = new Client({
	host: process.env.DB_HOST,
	port: process.env.DB_PORT,
	user: process.env.DB_USER,
	password: process.env.DB_PASS,
	database: process.env.DB_NAME,
	connectionTimeoutMillis: 5000, // 5 second timeout
	ssl: {
		rejectUnauthorized: false // For dev only; use proper certs in production
	}
});

async function testConnection() {
	try {
		console.log("Attempting to connect to DB...");
		await client.connect();
		console.log("✅ Connected to DB successfully!");

		// Test query
		const result = await client.query('SELECT NOW()');
		console.log("Current time from DB:", result.rows[0].now);

	} catch (err) {
		console.error("❌ DB connection error:", err.message);
		console.error("Error code:", err.code);
	} finally {
		await client.end();
		console.log("Connection closed");
	}
}

testConnection();