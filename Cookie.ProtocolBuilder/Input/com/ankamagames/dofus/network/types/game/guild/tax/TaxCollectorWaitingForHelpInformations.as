package com.ankamagames.dofus.network.types.game.guild.tax
{
   import com.ankamagames.dofus.network.types.game.fight.ProtectedEntityWaitingForHelpInfo;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TaxCollectorWaitingForHelpInformations extends TaxCollectorComplementaryInformations implements INetworkType
   {
      
      public static const protocolId:uint = 447;
       
      
      public var waitingForHelpInfo:ProtectedEntityWaitingForHelpInfo;
      
      private var _waitingForHelpInfotree:FuncTree;
      
      public function TaxCollectorWaitingForHelpInformations()
      {
         this.waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 447;
      }
      
      public function initTaxCollectorWaitingForHelpInformations(param1:ProtectedEntityWaitingForHelpInfo = null) : TaxCollectorWaitingForHelpInformations
      {
         this.waitingForHelpInfo = param1;
         return this;
      }
      
      override public function reset() : void
      {
         this.waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TaxCollectorWaitingForHelpInformations(param1);
      }
      
      public function serializeAs_TaxCollectorWaitingForHelpInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_TaxCollectorComplementaryInformations(param1);
         this.waitingForHelpInfo.serializeAs_ProtectedEntityWaitingForHelpInfo(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorWaitingForHelpInformations(param1);
      }
      
      public function deserializeAs_TaxCollectorWaitingForHelpInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
         this.waitingForHelpInfo.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorWaitingForHelpInformations(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorWaitingForHelpInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._waitingForHelpInfotree = param1.addChild(this._waitingForHelpInfotreeFunc);
      }
      
      private function _waitingForHelpInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
         this.waitingForHelpInfo.deserializeAsync(this._waitingForHelpInfotree);
      }
   }
}
