using Kitchen;
using KitchenData;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Linq;
using TheKarenMod.Card;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace TheKarenMod.System
{
    [UpdateAfter(typeof(GroupReceiveItem))]
    public class KarenSystem : GameSystemBase, IModSystem
    {
        private EntityQuery m_AwaitingOrderGroups;
        private EntityQuery m_ReadyToOrderGroups;
        private EntityQuery m_Customers;

        public int m_NumWaiting = 0;
        int karen_type_id;

        protected override void Initialise()
        {
            base.Initialise();

            m_AwaitingOrderGroups = GetEntityQuery(new QueryHelper()
                .All(typeof(CGroupAwaitingOrder))
            );

            m_ReadyToOrderGroups = GetEntityQuery(new QueryHelper()
                .All(typeof(CGroupReadyToOrder))
            );

            m_Customers = GetEntityQuery(new ComponentType[]
            {
                typeof(CCustomer),
                typeof(CCustomerType)
            });

            karen_type_id = GDOUtils.GetCustomGameDataObject<KarenCustomerType>().ID;
        }

        protected override void OnUpdate()
        {
            //OK so the idea is, see if its possible to check if there is less ppl waiting for food from prev update to now
            //if there is, then it means that there are people who are served, so minus the patience from all the karen's tables
            if (HasStatus((RestaurantStatus)VariousUtils.GetID("karen")))
            {
                NativeArray<Entity> awaiting_order_groups = m_AwaitingOrderGroups.ToEntityArray(Allocator.Temp);
                NativeArray<Entity> ready_to_order_groups = m_ReadyToOrderGroups.ToEntityArray(Allocator.Temp);

                if ((awaiting_order_groups.Length + ready_to_order_groups.Length) < m_NumWaiting)
                {
                    for (int i = 0; i < awaiting_order_groups.Length; i++)
                    {
                        if (KarenInGroup(awaiting_order_groups[i]))
                        {
                            if (Require(awaiting_order_groups[i], out CPatience cPatience))
                            {
                                cPatience.RemainingTime -= 0.025f;
                                EntityManager.SetComponentData(awaiting_order_groups[i], cPatience);
                            }
                        }
                    }

                    for (int i = 0; i < ready_to_order_groups.Length; i++)
                    {
                        if (KarenInGroup(ready_to_order_groups[i]))
                        {
                            if (Require(ready_to_order_groups[i], out CPatience cPatience))
                            {
                                cPatience.RemainingTime -= 0.025f;
                                EntityManager.SetComponentData(ready_to_order_groups[i], cPatience);
                            }
                        }
                    }
                }

                awaiting_order_groups.Dispose();
                ready_to_order_groups.Dispose();
                m_NumWaiting = awaiting_order_groups.Length + ready_to_order_groups.Length;
            }
        }

        private bool KarenInGroup(Entity group)
        {
            bool value = false;
            NativeArray<Entity> customers = m_Customers.ToEntityArray(Allocator.Temp);

            for (int i = 0; i < customers.Length; i++)
            {
                if (Require(customers[i], out CBelongsToGroup cBelongsToGroup))
                {
                    if (Require(customers[i], out CCustomerType cCustomerType))
                    {
                        if (cCustomerType.Type == karen_type_id)
                        {
                            if (cBelongsToGroup.Group == group)
                            {
                                value = true;
                                break;
                            }
                        }
                    }
                }
            }

            customers.Dispose();
            return value;
        }
    }
}
