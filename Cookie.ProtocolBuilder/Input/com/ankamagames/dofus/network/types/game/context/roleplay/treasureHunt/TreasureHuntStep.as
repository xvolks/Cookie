package com.ankamagames.dofus.network.types.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TreasureHuntStep implements INetworkType
   {
      
      public static const protocolId:uint = 463;
       
      
      public function TreasureHuntStep()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 463;
      }
      
      public function initTreasureHuntStep() : TreasureHuntStep
      {
         return this;
      }
      
      public function reset() : void
      {
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
      }
      
      public function serializeAs_TreasureHuntStep(param1:ICustomDataOutput) : void
      {
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
      }
      
      public function deserializeAs_TreasureHuntStep(param1:ICustomDataInput) : void
      {
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
      }
      
      public function deserializeAsyncAs_TreasureHuntStep(param1:FuncTree) : void
      {
      }
   }
}
