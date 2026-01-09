export interface ITask {
    id: number;
    completed: boolean;
    description?: string;
    createdAt: Date;
    updatedAt: Date;
    // priority: 'low' | 'medium' | 'high';
    // status: 'pending' | 'in-progress' | 'completed' | 'archived';

    priority: number;
    status: number;
}