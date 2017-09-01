package com.ankamagames.dofus.network.types.common.basic
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class StatisticDataInt extends StatisticData implements INetworkType
   {
      
      public static const protocolId:uint = 485;
       
      
      public var value:int = 0;
      
      public function StatisticDataInt()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 485;
      }
      
      public function initStatisticDataInt(param1:int = 0) : StatisticDataInt
      {
         this.value = param1;
         return this;
      }
      
      override public function reset() : void
      {
         this.value = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_StatisticDataInt(param1);
      }
      
      public function serializeAs_StatisticDataInt(param1:ICustomDataOutput) : void
      {
         super.serializeAs_StatisticData(param1);
         param1.writeInt(this.value);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StatisticDataInt(param1);
      }
      
      public function deserializeAs_StatisticDataInt(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._valueFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StatisticDataInt(param1);
      }
      
      public function deserializeAsyncAs_StatisticDataInt(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._valueFunc);
      }
      
      private function _valueFunc(param1:ICustomDataInput) : void
      {
         this.value = param1.readInt();
      }
   }
}
