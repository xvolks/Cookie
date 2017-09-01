package com.ankamagames.dofus.network.types.game.friend
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class IgnoredInformations extends AbstractContactInformations implements INetworkType
   {
      
      public static const protocolId:uint = 106;
       
      
      public function IgnoredInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 106;
      }
      
      public function initIgnoredInformations(param1:uint = 0, param2:String = "") : IgnoredInformations
      {
         super.initAbstractContactInformations(param1,param2);
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_IgnoredInformations(param1);
      }
      
      public function serializeAs_IgnoredInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractContactInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IgnoredInformations(param1);
      }
      
      public function deserializeAs_IgnoredInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IgnoredInformations(param1);
      }
      
      public function deserializeAsyncAs_IgnoredInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
      }
   }
}
