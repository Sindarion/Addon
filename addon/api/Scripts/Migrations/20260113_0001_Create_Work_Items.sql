-- Work_items table
CREATE TABLE work_items (
  id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
  parent_id uuid REFERENCES work_items(id) ON DELETE CASCADE,
  title varchar(255) NOT NULL,
  description varchar(4095),
  priority smallint NOT NULL,
  status smallint NOT NULL,
  estimated_time smallint NULL,
  estimated_cost NUMERIC(7,2),
  created_at timestamptz NOT NULL DEFAULT NOW(),
  updated_at timestamptz NULL
);

-- Prevent self-parenting
ALTER TABLE work_items
ADD CONSTRAINT no_self_parent
CHECK (parent_id IS NULL OR parent_id <> id);

-- Enable Row Level Security
ALTER TABLE public.work_items ENABLE ROW LEVEL SECURITY;