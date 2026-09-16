Order o1 = new Order
{
    OrderId = 1,
    CustomerName = "Ali"
};

STACK                         HEAP

┌──────────────┐
│ o1           │
│ address ────────────────►  ┌──────────────┐
└──────────────┘             │ Order        │
                             │ OrderId = 1  │
                             │ Customer=Ali │
                             │ IsPaid = ... │
                             │ ...          │
                             └──────────────┘


   


   Order o2 = o1;

   STACK                         HEAP

┌──────────────┐
│ o1 ──────────┼───────┐
└──────────────┘       │
                       ▼
                    ┌──────────────┐
                    │ Order        │
                    │ OrderId = 1  │
                    │ Customer=Ali │
                    └──────────────┘
                       ▲
┌──────────────┐       │
│ o2 ──────────┼───────┘
└──────────────┘



o2.IsPaid = true;

   STACK                         HEAP

┌──────────────┐
│ o1 ──────────┼───────┐
└──────────────┘       │
                       ▼
                    ┌──────────────┐
                    │ Order        │
                    │ OrderId = 1  │
                    │ IsPaid =true │
                    └──────────────┘
                       ▲
┌──────────────┐       │
│ o2 ──────────┼───────┘
└──────────────┘

## What would be different with structs?  
 Order o2 = o1; that would create a copy of the object in the stack. So if we change o2.IsPaid = true, it will not affect o1.IsPaid.