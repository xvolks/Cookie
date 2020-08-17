package com.ankamagames.dofus.network.messages.common.basic
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.common.basic.StatisticData;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AggregateStatWithDataMessage extends AggregateStatMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6662;
       
      
      private var _isInitialized:Boolean = false;
      
      public var datas:Vector.<StatisticData>;
      
      private var _datastree:FuncTree;
      
      public function AggregateStatWithDataMessage()
      {
         this.datas = new Vector.<StatisticData>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6662;
      }
      
      public function initAggregateStatWithDataMessage(param1:uint = 0, param2:Vector.<StatisticData> = null) : AggregateStatWithDataMessage
      {
         super.initAggregateStatMessage(param1);
         this.datas = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.datas = new Vector.<StatisticData>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AggregateStatWithDataMessage(param1);
      }
      
      public function serializeAs_AggregateStatWithDataMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AggregateStatMessage(param1);
         param1.writeShort(this.datas.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.datas.length)
         {
            param1.writeShort((this.datas[_loc2_] as StatisticData).getTypeId());
            (this.datas[_loc2_] as StatisticData).serialize(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AggregateStatWithDataMessage(param1);
      }
      
      public function deserializeAs_AggregateStatWithDataMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:StatisticData = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(StatisticData,_loc4_);
            _loc5_.deserialize(param1);
            this.datas.push(_loc5_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AggregateStatWithDataMessage(param1);
      }
      
      public function deserializeAsyncAs_AggregateStatWithDataMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._datastree = param1.addChild(this._datastreeFunc);
      }
      
      private function _datastreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._datastree.addChild(this._datasFunc);
            _loc3_++;
         }
      }
      
      private function _datasFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:StatisticData = ProtocolTypeManager.getInstance(StatisticData,_loc2_);
         _loc3_.deserialize(param1);
         this.datas.push(_loc3_);
      }
   }
}
