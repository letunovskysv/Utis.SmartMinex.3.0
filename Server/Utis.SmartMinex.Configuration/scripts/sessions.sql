SELECT * FROM pg_stat_activity WHERE pg_stat_activity.datname = current_database() AND pid <> pg_backend_pid();

/* Закрыть ползовательские сессии */
SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE pg_stat_activity.datname = current_database() AND pid <> pg_backend_pid();
