package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightResultAdditionalData implements INetworkType
   {
      
      public static const protocolId:uint = 191;
       
      
      public function FightResultAdditionalData()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 191;
      }
      
      public function initFightResultAdditionalData() : FightResultAdditionalData
      {
         return this;
      }
      
      public function reset() : void
      {
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
      }
      
      public function serializeAs_FightResultAdditionalData(param1:ICustomDataOutput) : void
      {
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
      }
      
      public function deserializeAs_FightResultAdditionalData(param1:ICustomDataInput) : void
      {
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
      }
      
      public function deserializeAsyncAs_FightResultAdditionalData(param1:FuncTree) : void
      {
      }
   }
}
