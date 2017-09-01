package com.ankamagames.dofus.network.types.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TreasureHuntStepDig extends TreasureHuntStep implements INetworkType
   {
      
      public static const protocolId:uint = 465;
       
      
      public function TreasureHuntStepDig()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 465;
      }
      
      public function initTreasureHuntStepDig() : TreasureHuntStepDig
      {
         return this;
      }
      
      override public function reset() : void
      {
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
      }
      
      public function serializeAs_TreasureHuntStepDig(param1:ICustomDataOutput) : void
      {
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
      }
      
      public function deserializeAs_TreasureHuntStepDig(param1:ICustomDataInput) : void
      {
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
      }
      
      public function deserializeAsyncAs_TreasureHuntStepDig(param1:FuncTree) : void
      {
      }
   }
}
